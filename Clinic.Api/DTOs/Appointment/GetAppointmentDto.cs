namespace Clinic.Api.DTOs.Appointment;

/// <summary>
/// DTO for retrieving detailed information about an appointment,
/// including patient and doctor IDs/names, appointment date, room number, and return visit flag.
/// </summary>

public class GetAppointmentDto
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public string PatientFullName { get; set; } = null!;
    public string DoctorFullName { get; set; } = null!;
    public DateOnly DateTime { get; set; }
    public int RoomNumber { get; set; }
    public bool IsReturnVisit { get; set; }
}
