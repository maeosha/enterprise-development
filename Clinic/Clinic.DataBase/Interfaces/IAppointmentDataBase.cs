using Clinic.Models.Entities;

namespace Clinic.DataBase.Interfaces;

/// <summary>
/// Abstraction for appointment persistence operations.
/// Provides methods to query and modify appointments in the data store.
/// </summary>
public interface IAppointmentDataBase
{
    /// <summary>
    /// Retrieves an appointment by identifier.
    /// </summary>
    public Appointment? GetAppointment(int id);

    /// <summary>
    /// Returns all appointments.
    /// </summary>
    public IReadOnlyCollection<Appointment> GetAllAppointments();

    /// <summary>
    /// Returns appointments for the specified doctor.
    /// </summary>
    public IReadOnlyCollection<Appointment> GetAppointmentsByDoctor(int doctorId);

    /// <summary>
    /// Returns appointments for the specified patient.
    /// </summary>
    public IReadOnlyCollection<Appointment> GetAppointmentsByPatient(int patientId);

    /// <summary>
    /// Adds a new appointment. Returns <c>true</c> on success.
    /// </summary>
    public bool AddAppointment(Appointment appointment);

    /// <summary>
    /// Updates an appointment. Returns <c>true</c> if updated.
    /// </summary>
    public bool UpdateAppointment(Appointment appointment);

    /// <summary>
    /// Removes an appointment by id. Returns <c>true</c> if removed.
    /// </summary>
    public bool RemoveAppointment(int id);

    /// <summary>
    /// Returns total number of appointments.
    /// </summary>
    public int AppointmentCount();
}


