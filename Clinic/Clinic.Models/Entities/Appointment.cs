namespace Clinic.Models.Entities;

/// <summary>
/// Represents an appointment in the clinic, including patient, doctor, date/time, room, and visit type.
/// </summary>
public class Appointment
{
    /// <summary>
    /// Gets or sets the unique identifier for the appointment.
    /// </summary>
    required public int Id { get; set; }

    /// <summary>
    /// Gets or sets the patient identifier for the appointment.
    /// </summary>
    required public int PatientId { get; set; }

    /// <summary>
    /// Gets or sets the full name of the patient at the time of appointment.
    /// </summary>
    required public string PatientFullName { get; set; } = null!;

    /// <summary>
    /// Gets or sets the doctor identifier for the appointment.
    /// </summary>
    required public int DoctorId { get; set; }

    /// <summary>
    /// Gets or sets the full name of the doctor at the time of appointment.
    /// </summary>
    required public string DoctorFullName { get; set; } = null!;

    /// <summary>
    /// Gets or sets the date and time of the appointment.
    /// </summary>
    required public DateTime DateTime { get; set; }

    /// <summary>
    /// Gets or sets the room number for the appointment.
    /// </summary>
    required public int RoomNumber { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this appointment is a return visit.
    /// </summary>
    required public bool IsReturnVisit { get; set; }
}
