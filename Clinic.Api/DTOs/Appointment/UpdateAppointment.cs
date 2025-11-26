namespace Clinic.Api.DTOs.Appointment;

/// <summary>
/// DTO for updating an existing appointment, including optional patient/doctor information,
/// scheduled date/time, room number, and return visit flag.
/// </summary>
public class UpdateAppointmentDto
{
    public int? PatientId { get; set; } = null;
    public int? DoctorId { get; set; } = null;
    public DateTime? DateTime { get; set; } = null;
    public int? RoomNumber { get; set; } = null;
    public bool? IsReturnVisit { get; set; } = null;
}
