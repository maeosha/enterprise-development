using Clinic.Application.Ports;
using Clinic.Models.Entities;

namespace Clinic.InMemory;
public sealed class InMemoryAppointmentRepository : IAppointmentRepository
{
    /// <summary>
    /// In-memory storage for appointments.
    /// </summary>
    private readonly Dictionary<int, Appointment> _appointments = new();

    /// <summary>
    /// Retrieves an appointment by its ID.
    /// </summary>
    /// <param name="Id">The ID of the appointment to retrieve.</param>
    /// <returns>The appointment with the specified ID, or null if not found.</returns>
    public Appointment? GetAppointment(int id) => _appointments.GetValueOrDefault(id);

    /// <summary>
    /// Retrieves all appointments from the in-memory storage.
    /// </summary>
    /// <returns>A read-only collection of all appointments.</returns>
    public IReadOnlyCollection<Appointment> GetAllAppointments() => _appointments.Values;

    /// <summary>
    /// Retrieves all appointments associated with a specific doctor.
    /// </summary>
    /// <param name="Id">The ID of the doctor.</param>
    /// <returns>A read-only collection of appointments for the specified doctor.</returns>
    public IReadOnlyCollection<Appointment> GetAppointmentsByDoctor(int doctorId) =>
        _appointments.Values.Where(a => a.DoctorId == doctorId).ToList();

    /// <summary>
    /// Retrieves all appointments associated with a specific patient.
    /// </summary>
    /// <param name="Id">The ID of the patient.</param>
    /// <returns>A read-only collection of appointments for the specified patient.</returns>
    public IReadOnlyCollection<Appointment> GetAppointmentsByPatient(int patientId) =>
        _appointments.Values.Where(a => a.PatientId == patientId).ToList();

    /// <summary>
    /// Adds a new appointment to the in-memory storage.
    /// </summary>
    /// <param name="appointment">The appointment to add.</param>
    /// <returns>True if the appointment was successfully added, false if it already exists.</returns>
    public bool AddAppointment(Appointment appointment){
        if (_appointments.ContainsKey(appointment.Id)){
            return false;
        }

        _appointments[appointment.Id] = appointment;
        return true;
    }

    /// <summary>
    /// Updates an existing appointment in the in-memory storage.
    /// </summary>
    /// <param name="appointment">The appointment with updated information.</param>
    /// <returns>True if the appointment was successfully updated, false if it doesn't exist.</returns>
    public bool UpdateAppointment(Appointment appointment){
        if (!_appointments.ContainsKey(appointment.Id)){
            return false;
        }

        _appointments[appointment.Id] = appointment;
        return true;
    }

    /// <summary>
    /// Removes an appointment from the in-memory storage.
    /// </summary>
    /// <param name="Id">The ID of the appointment to remove.</param>
    /// <returns>True if the appointment was successfully removed, false if it doesn't exist.</returns>
    public bool RemoveAppointment(int id) => _appointments.Remove(id);

    /// <summary>
    /// Gets the count of appointments in the in-memory storage.
    /// </summary>
    /// <returns>The number of appointments.</returns>
    public int AppointmentCount() => _appointments.Count();
}
