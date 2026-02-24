using System.Globalization;
using Clinic.Contracts;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using Npgsql;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true)
    .AddEnvironmentVariables()
    .Build();

var endpoint = configuration["Grpc:Endpoint"];
if (string.IsNullOrWhiteSpace(endpoint))
{
    Console.Error.WriteLine("Missing Grpc:Endpoint configuration.");
    return 1;
}

var aspireHttpsEndpoint = Environment.GetEnvironmentVariable("services__clinic-api__https__0");
var aspireHttpEndpoint = Environment.GetEnvironmentVariable("services__clinic-api__http__0");
if (endpoint.Contains("clinic-api", StringComparison.OrdinalIgnoreCase))
{
    endpoint = aspireHttpsEndpoint ?? aspireHttpEndpoint ?? endpoint;
}

var connectionString = configuration.GetConnectionString("ClinicDb");
if (string.IsNullOrWhiteSpace(connectionString))
{
    Console.Error.WriteLine("Missing ConnectionStrings:ClinicDb configuration.");
    return 1;
}

if (endpoint.StartsWith("http://", StringComparison.OrdinalIgnoreCase))
{
    AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
}

var count = configuration.GetValue("Generator:Count", 10);
var roomNumbers = configuration.GetSection("Generator:RoomNumbers").Get<int[]>() ?? [101, 102, 201, 202];

var patients = new List<(int Id, string FullName)>();
var doctors = new List<(int Id, string FullName)>();
var knownVisitPairs = new HashSet<(int PatientId, int DoctorId)>();

const int maxAttempts = 20;

// Attempt to read patients, doctors and known visit pairs with retry logic for database readiness.
for (var attempt = 1; attempt <= maxAttempts; attempt++)
{
    try
    {
        patients.Clear();
        doctors.Clear();
        knownVisitPairs.Clear();

        await using var connection = new NpgsqlConnection(connectionString);
        await connection.OpenAsync();

        await using (var command = new NpgsqlCommand("SELECT \"Id\", \"LastName\", \"FirstName\", \"Patronymic\" FROM \"Patients\"", connection))
        await using (var reader = await command.ExecuteReaderAsync())
        {
            while (await reader.ReadAsync())
            {
                var id = reader.GetInt32(0);
                var lastName = reader.GetString(1);
                var firstName = reader.GetString(2);
                var patronymic = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                var fullName = BuildFullName(lastName, firstName, patronymic);
                patients.Add((id, fullName));
            }
        }

        await using (var command = new NpgsqlCommand("SELECT \"Id\", \"LastName\", \"FirstName\", \"Patronymic\" FROM \"Doctors\"", connection))
        await using (var reader = await command.ExecuteReaderAsync())
        {
            while (await reader.ReadAsync())
            {
                var id = reader.GetInt32(0);
                var lastName = reader.GetString(1);
                var firstName = reader.GetString(2);
                var patronymic = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                var fullName = BuildFullName(lastName, firstName, patronymic);
                doctors.Add((id, fullName));
            }
        }

        await using (var command = new NpgsqlCommand("SELECT DISTINCT \"PatientId\", \"DoctorId\" FROM \"Appointments\"", connection))
        await using (var reader = await command.ExecuteReaderAsync())
        {
            while (await reader.ReadAsync())
            {
                knownVisitPairs.Add((reader.GetInt32(0), reader.GetInt32(1)));
            }
        }

        break;
    }
    catch (PostgresException ex) when (ex.SqlState == "42P01" && attempt < maxAttempts)
    {
        Console.WriteLine($"Database schema is not ready yet (attempt {attempt}/{maxAttempts}). Retrying...");
        await Task.Delay(TimeSpan.FromSeconds(2));
    }
    catch (NpgsqlException) when (attempt < maxAttempts)
    {
        Console.WriteLine($"Database is not ready yet (attempt {attempt}/{maxAttempts}). Retrying...");
        await Task.Delay(TimeSpan.FromSeconds(2));
    }
}

if (count <= 0)
{
    Console.Error.WriteLine("Generator:Count must be greater than 0.");
    return 1;
}

if (roomNumbers.Length == 0)
{
    Console.Error.WriteLine("Generator:RoomNumbers is empty.");
    return 1;
}

if (patients.Count == 0 || doctors.Count == 0)
{
    Console.Error.WriteLine("No patients or doctors found in the database after retries.");
    return 1;
}

//Create gRPC channel and client, then send generated contracts with retry logic for endpoint availability.
const int grpcAttempts = 10;
for (var attempt = 1; attempt <= grpcAttempts; attempt++)
{
    try
    {
        using var channel = GrpcChannel.ForAddress(endpoint);
        var client = new ContractIngestor.ContractIngestorClient(channel);

        using var call = client.IngestContracts();
        var random = new Random();

        for (var i = 0; i < count; i++)
        {
            var patient = patients[random.Next(patients.Count)];
            var doctor = doctors[random.Next(doctors.Count)];
            var contract = BuildRandomContract(patient, doctor, roomNumbers, random, knownVisitPairs);

            await call.RequestStream.WriteAsync(contract);
        }

        await call.RequestStream.CompleteAsync();

        var result = await call;
        Console.WriteLine($"Received={result.Received} Saved={result.Saved} Failed={result.Failed}");
        foreach (var error in result.Errors)
        {
            Console.WriteLine(error);
        }

        return 0;
    }
    catch (Grpc.Core.RpcException ex) when (ex.StatusCode == Grpc.Core.StatusCode.Unavailable && attempt < grpcAttempts)
    {
        Console.WriteLine($"gRPC endpoint is not ready yet (attempt {attempt}/{grpcAttempts}). Retrying...");
        await Task.Delay(TimeSpan.FromSeconds(2));
    }
}

Console.Error.WriteLine("Failed to send contracts to gRPC endpoint after retries.");
return 1;

/// <summary>
/// Builds a full name from separate name parts.
/// </summary>
/// <param name="lastName">Person last name.</param>
/// <param name="firstName">Person first name.</param>
/// <param name="patronymic">Optional middle name.</param>
/// <returns>Concatenated full name without extra whitespace.</returns>
static string BuildFullName(string lastName, string firstName, string? patronymic)
{
    return string.IsNullOrWhiteSpace(patronymic)
        ? $"{lastName} {firstName}"
        : $"{lastName} {firstName} {patronymic}";
}

/// <summary>
/// Creates a randomized appointment contract for gRPC streaming.
/// </summary>
/// <param name="patient">Source patient identity tuple.</param>
/// <param name="doctor">Source doctor identity tuple.</param>
/// <param name="roomNumbers">Available room numbers.</param>
/// <param name="random">Random generator instance.</param>
/// <param name="knownVisitPairs">Known patient-doctor pairs that already had visits.</param>
/// <returns>Prepared <see cref="Contract"/> with randomized date and flags.</returns>
static Contract BuildRandomContract(
    (int Id, string FullName) patient,
    (int Id, string FullName) doctor,
    int[] roomNumbers,
    Random random,
    HashSet<(int PatientId, int DoctorId)> knownVisitPairs)
{
    var pair = (patient.Id, doctor.Id);
    var isReturnVisit = knownVisitPairs.Contains(pair);
    knownVisitPairs.Add(pair);

    var appointmentTime = DateTimeOffset.UtcNow
        .AddDays(random.Next(0, 30))
        .AddHours(random.Next(8, 18))
        .AddMinutes(random.Next(0, 60))
        .ToString("O", CultureInfo.InvariantCulture);

    return new Contract
    {
        PatientId = patient.Id,
        PatientFullName = patient.FullName,
        DoctorId = doctor.Id,
        DoctorFullName = doctor.FullName,
        AppointmentTime = appointmentTime,
        RoomNumber = roomNumbers[random.Next(roomNumbers.Length)],
        IsReturnVisit = isReturnVisit
    };
}
