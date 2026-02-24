using System.Globalization;
using Clinic.Application.Ports;
using Clinic.Contracts;
using Clinic.Models.Entities;
using Grpc.Core;

namespace Clinic.Api.Grpc;

/// <summary>
/// gRPC service that ingests appointment contracts from a client stream
/// and persists mapped appointments to storage.
/// </summary>
public class ContractIngestService : ContractIngestor.ContractIngestorBase
{
    private readonly IAppointmentRepository _appointments;
    private readonly ILogger<ContractIngestService> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="ContractIngestService"/> class.
    /// </summary>
    /// <param name="appointments">Appointment repository used to persist mapped contracts.</param>
    /// <param name="logger">Logger for ingest diagnostics and persistence errors.</param>
    public ContractIngestService(IAppointmentRepository appointments, ILogger<ContractIngestService> logger)
    {
        _appointments = appointments;
        _logger = logger;
    }

    /// <summary>
    /// Reads contracts from the incoming gRPC stream, validates and maps them to appointments,
    /// and returns aggregated ingest statistics.
    /// </summary>
    /// <param name="requestStream">Incoming stream of contracts.</param>
    /// <param name="context">Server call context for cancellation and metadata.</param>
    /// <returns>Ingest result with total received, saved, failed and error details.</returns>
    public override async Task<IngestResult> IngestContracts(IAsyncStreamReader<Contract> requestStream, ServerCallContext context)
    {
        var received = 0;
        var saved = 0;
        var failed = 0;
        var errors = new List<string>();

        await foreach (var contract in requestStream.ReadAllAsync(context.CancellationToken))
        {
            received++;
            if (!TryMap(contract, out var appointment, out var error))
            {
                failed++;
                errors.Add($"#{received}: {error}");
                continue;
            }

            try
            {
                if (_appointments.AddAppointment(appointment))
                {
                    saved++;
                    _logger.LogInformation(
                        "Appointment added from stream. AppointmentId: {AppointmentId}, PatientId: {PatientId}, DoctorId: {DoctorId}, DateTime: {DateTime}",
                        appointment.Id,
                        appointment.PatientId,
                        appointment.DoctorId,
                        appointment.DateTime);
                }
                else
                {
                    failed++;
                    errors.Add($"#{received}: Appointment already exists.");
                }
            }
            catch (Exception ex)
            {
                failed++;
                errors.Add($"#{received}: {ex.Message}");
                _logger.LogWarning(ex, "Failed to persist contract #{Index}", received);
            }
        }

        var result = new IngestResult
        {
            Received = received,
            Saved = saved,
            Failed = failed
        };
        result.Errors.AddRange(errors);

        return result;
    }

    /// <summary>
    /// Validates contract payload and converts it to an <see cref="Appointment"/>.
    /// </summary>
    /// <param name="contract">Source contract.</param>
    /// <param name="appointment">Mapped appointment if conversion succeeds.</param>
    /// <param name="error">Validation or conversion error message.</param>
    /// <returns><c>true</c> when contract is valid and mapped; otherwise, <c>false</c>.</returns>
    private static bool TryMap(Contract contract, out Appointment appointment, out string error)
    {
        appointment = null!;
        error = string.Empty;

        if (contract.PatientId <= 0)
        {
            error = "PatientId must be positive.";
            return false;
        }

        if (contract.DoctorId <= 0)
        {
            error = "DoctorId must be positive.";
            return false;
        }

        if (string.IsNullOrWhiteSpace(contract.PatientFullName))
        {
            error = "PatientFullName is required.";
            return false;
        }

        if (string.IsNullOrWhiteSpace(contract.DoctorFullName))
        {
            error = "DoctorFullName is required.";
            return false;
        }

        if (!DateTimeOffset.TryParse(contract.AppointmentTime, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var dateTimeOffset))
        {
            error = "AppointmentTime must be ISO-8601.";
            return false;
        }

        appointment = new Appointment
        {
            Id = 0,
            PatientId = contract.PatientId,
            PatientFullName = contract.PatientFullName,
            DoctorId = contract.DoctorId,
            DoctorFullName = contract.DoctorFullName,
            DateTime = dateTimeOffset.UtcDateTime,
            RoomNumber = contract.RoomNumber,
            IsReturnVisit = contract.IsReturnVisit
        };

        return true;
    }
}
