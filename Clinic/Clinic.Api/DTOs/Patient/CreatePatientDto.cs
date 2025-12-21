namespace Clinic.Api.DTOs.PatientDto;

/// <summary>
/// DTO for creating a new patient, including required personal information,
/// medical history, and contact details.
/// </summary>
public class CreatePatientDto
{
    /// <summary>
    /// The patient's first name.
    /// </summary>
    public required string FirstName { get; set; }

    /// <summary>
    /// The patient's last name.
    /// </summary>
    public required string LastName { get; set; }

    /// <summary>
    /// Optional patronymic (middle name) of the patient.
    /// </summary>
    public string? Patronymic { get; set; }

    /// <summary>
    /// The patient's passport number.
    /// </summary>
    public required string PassportNumber { get; set; }

    /// <summary>
    /// The patient's birth date.
    /// </summary>
    public required DateOnly BirthDate { get; set; }

    /// <summary>
    /// The patient's gender as a string (e.g. "Male", "Female").
    /// </summary>
    public required String Gender { get; set; }

    /// <summary>
    /// The patient's residential address.
    /// </summary>
    public required string Address { get; set; }

    /// <summary>
    /// The patient's contact phone number.
    /// </summary>
    public required string PhoneNumber { get; set; }

    /// <summary>
    /// The patient's blood group as a string (e.g. "A", "B", "AB", "O").
    /// </summary>
    public required String BloodGroup { get; set; }

    /// <summary>
    /// The patient's rhesus factor as a string (e.g. "Positive", "Negative").
    /// </summary>
    public required String RhesusFactor { get; set; }
}