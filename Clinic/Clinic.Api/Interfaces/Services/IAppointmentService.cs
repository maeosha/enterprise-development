using Clinic.Api.DTOs.Appointment;
using Clinic.Api.Interfaces;

namespace Clinic.Api.Interfaces.Services;

/// <summary>
/// Interface for appointment service operations.
/// Provides methods for managing appointments in the clinic system.
/// </summary>
public interface IAppointmentServices : IBaseServices<GetAppointmentDto, CreateAppointmentDto, UpdateAppointmentDto>
{
    /// <summary>
    /// Retrieves all appointments for a specific doctor.
    /// </summary>
    /// <param name="doctorId">The identifier of the doctor.</param>
    /// <returns>A collection of appointment DTOs if the doctor exists; otherwise, null.</returns>
    public IReadOnlyCollection<GetAppointmentDto>? GetAppointmentsByDoctor(int doctorId);

    /// <summary>
    /// Retrieves all appointments for a specific patient.
    /// </summary>
    /// <param name="patientId">The identifier of the patient.</param>
    /// <returns>A collection of appointment DTOs if the patient exists; otherwise, null.</returns>
    public IReadOnlyCollection<GetAppointmentDto>? GetAppointmentsByPatient(int patientId);
}

