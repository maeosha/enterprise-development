namespace Clinic.Application.DTOs.Patient;

/// <summary>
/// DTO for retrieving detailed information about a patient,
/// including personal details, medical history, and contact details.
/// </summary>
public class GetPatientDto
{
    /// <summary>
    /// The unique identifier of the patient.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The patient's first name.
    /// </summary>
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// The patient's last name.
    /// </summary>
    public string LastName { get; set; } = null!;

    /// <summary>
    /// Optional patronymic (middle name) of the patient.
    /// </summary>
    public string? Patronymic { get; set; }

    /// <summary>
    /// The patient's birth date.
    /// </summary>
    public DateOnly BirthDate { get; set; }

    /// <summary>
    /// The patient's gender as a string.
    /// </summary>
    public String Gender { get; set; } = null!;

    /// <summary>
    /// The patient's blood group as a string (A, B, AB, O).
    /// </summary>
    public String BloodGroup { get; set; } = null!;

    /// <summary>
    /// The patient's rhesus factor as a string (Positive/Negative).
    /// </summary>
    public String RhesusFactor { get; set; } = null!;
}