namespace Clinic.Models.Entities;

/// <summary>
/// Represents an appointment in the clinic, including patient, doctor, date/time, room, and visit type.
/// </summary>
public class Appointment
{
    /// <summary>
    /// Gets or sets the patient for the appointment.
    /// </summary>
    required public Patient Patient { get; set; }

    /// <summary>
    /// Gets or sets the doctor for the appointment.
    /// </summary>
    required public Doctor Doctor { get; set; }

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
