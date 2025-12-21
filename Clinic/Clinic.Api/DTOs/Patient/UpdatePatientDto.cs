using Clinic.Models.Enums;

namespace Clinic.Api.DTOs.PatientDto;

/// <summary>
/// DTO for updating an existing patient, including optional personal information,
/// medical history, and contact details.
/// </summary>
public class UpdatePatientDto
{
    /// <summary>
    /// Optional new first name for the patient.
    /// </summary>
    public string? FirstName { get; set; } = null;

    /// <summary>
    /// Optional new last name for the patient.
    /// </summary>
    public string? LastName { get; set; } = null;

    /// <summary>
    /// Optional new patronymic (middle name) for the patient.
    /// </summary>
    public string? Patronymic { get; set; } = null;

    /// <summary>
    /// Optional new date of birth for the patient.
    /// </summary>
    public DateTime? DateOfBirth { get; set; } = null;

    /// <summary>
    /// Optional new address for the patient.
    /// </summary>
    public string? Address { get; set; } = null;

    /// <summary>
    /// Optional new phone number for the patient.
    /// </summary>
    public string? PhoneNumber { get; set; } = null;

    /// <summary>
    /// Optional new blood group for the patient.
    /// </summary>
    public BloodGroup? BloodGroup { get; set; } = null;

    /// <summary>
    /// Optional new rhesus factor for the patient.
    /// </summary>
    public RhesusFactor? RhesusFactor { get; set; } = null;
}