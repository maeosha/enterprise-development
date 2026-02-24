using System.Globalization;
using Clinic.Contracts;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using var loggerFactory = LoggerFactory.Create(builder =>
{
    builder
        .SetMinimumLevel(LogLevel.Information)
        .AddSimpleConsole(options =>
        {
            options.SingleLine = true;
            options.TimestampFormat = "HH:mm:ss ";
        });
});
var logger = loggerFactory.CreateLogger("Clinic.AppointmentGenerator");

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true)
    .AddEnvironmentVariables()
    .Build();

var endpoint = configuration["Grpc:Endpoint"];
if (string.IsNullOrWhiteSpace(endpoint))
{
    logger.LogError("Missing Grpc:Endpoint configuration.");
    return 1;
}

var aspireHttpsEndpoint = Environment.GetEnvironmentVariable("services__clinic-api__https__0");
var aspireHttpEndpoint = Environment.GetEnvironmentVariable("services__clinic-api__http__0");
if (endpoint.Contains("clinic-api", StringComparison.OrdinalIgnoreCase))
{
    endpoint = aspireHttpsEndpoint ?? aspireHttpEndpoint ?? endpoint;
}

if (endpoint.StartsWith("http://", StringComparison.OrdinalIgnoreCase))
{
    logger.LogWarning("Using insecure gRPC endpoint {Endpoint}. Enabling Http2UnencryptedSupport.", endpoint);
    AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
}

var count = configuration.GetValue("Generator:Count", 10);
var roomNumbers = configuration.GetSection("Generator:RoomNumbers").Get<int[]>() ?? [101, 102, 201, 202];
var patients = configuration.GetSection("Generator:Patients").Get<PersonSeed[]>() ??
[
    new PersonSeed(1, "Иванов Иван Иванович"),
    new PersonSeed(2, "Петров Петр Петрович"),
    new PersonSeed(3, "Сидорова Мария Алексеевна")
];
var doctors = configuration.GetSection("Generator:Doctors").Get<PersonSeed[]>() ??
[
    new PersonSeed(1, "Смирнов Алексей Николаевич"),
    new PersonSeed(2, "Кузнецова Елена Сергеевна"),
    new PersonSeed(3, "Волков Дмитрий Олегович")
];

var knownVisitPairs = new HashSet<(int PatientId, int DoctorId)>();

if (count <= 0)
{
    logger.LogError("Generator:Count must be greater than 0.");
    return 1;
}

if (roomNumbers.Length == 0)
{
    logger.LogError("Generator:RoomNumbers is empty.");
    return 1;
}

if (patients.Length == 0 || doctors.Length == 0)
{
    logger.LogError("Generator:Patients and Generator:Doctors must contain at least one item.");
    return 1;
}

logger.LogInformation(
    "Generator started. Endpoint={Endpoint}; Count={Count}; Patients={PatientsCount}; Doctors={DoctorsCount}.",
    endpoint,
    count,
    patients.Length,
    doctors.Length);

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
            var patient = patients[random.Next(patients.Length)];
            var doctor = doctors[random.Next(doctors.Length)];
            var contract = BuildRandomContract(patient, doctor, roomNumbers, random, knownVisitPairs);

            await call.RequestStream.WriteAsync(contract);
            logger.LogInformation(
                "Sent contract {Index}/{Total}: PatientId={PatientId}; DoctorId={DoctorId}; Room={Room}; IsReturnVisit={IsReturnVisit}; Time={Time}.",
                i + 1,
                count,
                contract.PatientId,
                contract.DoctorId,
                contract.RoomNumber,
                contract.IsReturnVisit,
                contract.AppointmentTime);
        }

        await call.RequestStream.CompleteAsync();

        var result = await call;
        logger.LogInformation("Ingest result: Received={Received}; Saved={Saved}; Failed={Failed}.", result.Received, result.Saved, result.Failed);
        foreach (var error in result.Errors)
        {
            logger.LogWarning("Ingest error: {Error}", error);
        }

        return 0;
    }
    catch (Grpc.Core.RpcException ex) when (ex.StatusCode == Grpc.Core.StatusCode.Unavailable && attempt < grpcAttempts)
    {
        logger.LogWarning("gRPC endpoint is not ready yet (attempt {Attempt}/{MaxAttempts}). Retrying...", attempt, grpcAttempts);
        await Task.Delay(TimeSpan.FromSeconds(2));
    }
}

logger.LogError("Failed to send contracts to gRPC endpoint after retries.");
return 1;

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
    PersonSeed patient,
    PersonSeed doctor,
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

/// <summary>
/// Seed entity used by the autonomous generator to avoid direct database dependency.
/// </summary>
/// <param name="Id">Domain identifier used in generated contracts.</param>
/// <param name="FullName">Full name included in generated contracts.</param>
readonly record struct PersonSeed(int Id, string FullName);
