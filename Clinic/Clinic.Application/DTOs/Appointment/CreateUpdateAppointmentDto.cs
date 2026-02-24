namespace Clinic.Application.DTOs.Appointment;

/// <summary>
/// DTO for creating a new appointment, including required patient/doctor information, 
/// scheduled date/time, room number, and return visit flag.
/// </summary>
public class CreateUpdateAppointmentDto
{
    /// <summary>
    /// The full name of the patient for the appointment.
    /// </summary>
    public required string PatientFullName { get; set; }

    /// <summary>
    /// The full name of the doctor for the appointment.
    /// </summary>
    public required string DoctorFullName { get; set; }

    /// <summary>
    /// The date and time of the appointment.
    /// </summary>
    public required DateTime DateTime { get; set; }

    /// <summary>
    /// The room number where the appointment will take place.
    /// </summary>
    public required int RoomNumber { get; set; }

    /// <summary>
    /// Indicates whether the appointment is a return visit.
    /// </summary>
    public required bool IsReturnVisit { get; set; }
}
