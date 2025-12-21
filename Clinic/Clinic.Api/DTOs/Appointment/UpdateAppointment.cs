namespace Clinic.Api.DTOs.Appointment;

/// <summary>
/// DTO for updating an existing appointment, including optional patient/doctor information,
/// scheduled date/time, room number, and return visit flag.
/// </summary>
public class UpdateAppointmentDto
{
    /// <summary>
    /// Optional: The ID of the patient to update for the appointment.
    /// </summary>
    public int? PatientId { get; set; } = null;

    /// <summary>
    /// Optional: The ID of the doctor to update for the appointment.
    /// </summary>
    public int? DoctorId { get; set; } = null;

    /// <summary>
    /// Optional: The new date and time for the appointment.
    /// </summary>
    public DateTime? DateTime { get; set; } = null;

    /// <summary>
    /// Optional: The new room number for the appointment.
    /// </summary>
    public int? RoomNumber { get; set; } = null;

    /// <summary>
    /// Optional: Flag indicating if this is a return visit.
    /// </summary>
    public bool? IsReturnVisit { get; set; } = null;
}