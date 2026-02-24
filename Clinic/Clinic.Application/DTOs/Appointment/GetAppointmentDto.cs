namespace Clinic.Application.DTOs.Appointment;

/// <summary>
/// DTO for retrieving detailed information about an appointment,
/// including patient and doctor IDs/names, appointment date, room number, and return visit flag.
/// </summary>

public class GetAppointmentDto
{
    /// <summary>
    /// The unique identifier of the appointment.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The ID of the patient associated with the appointment.
    /// </summary>
    public int PatientId { get; set; }

    /// <summary>
    /// The ID of the doctor associated with the appointment.
    /// </summary>
    public int DoctorId { get; set; }

    /// <summary>
    /// The full name of the patient.
    /// </summary>
    public string PatientFullName { get; set; } = null!;

    /// <summary>
    /// The full name of the doctor.
    /// </summary>
    public string DoctorFullName { get; set; } = null!;

    /// <summary>
    /// The date and time of the appointment.
    /// </summary>
    public DateTime DateTime { get; set; }

    /// <summary>
    /// The room number where the appointment takes place.
    /// </summary>
    public int RoomNumber { get; set; }

    /// <summary>
    /// Indicates whether this is a return visit for the patient.
    /// </summary>
    public bool IsReturnVisit { get; set; }
}
