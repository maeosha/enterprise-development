using System.ComponentModel.DataAnnotations;

namespace Clinic.Api.DTOs.Appointment;

/// <summary>
/// DTO for creating a new appointment, including required patient/doctor information, 
/// scheduled date/time, room number, and return visit flag.
/// </summary>
public class CreateAppointmentDto
{
    /// <summary>
    /// The full name of the patient for the appointment.
    /// </summary>
    [Required]
    public string PatientFullName { get; set; } = null!;

    /// <summary>
    /// The full name of the doctor for the appointment.
    /// </summary>
    [Required]
    public string DoctorFullName { get; set; } = null!;

    /// <summary>
    /// The date and time of the appointment.
    /// </summary>
    [Required]
    public DateTime DateTime { get; set; }

    /// <summary>
    /// The room number where the appointment will take place.
    /// </summary>
    [Required]
    public int RoomNumber { get; set; }

    /// <summary>
    /// Indicates whether the appointment is a return visit.
    /// </summary>
    [Required]
    public bool IsReturnVisit { get; set; }
}
