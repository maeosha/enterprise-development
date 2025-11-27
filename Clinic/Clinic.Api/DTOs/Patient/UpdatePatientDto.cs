using Clinic.Models.Enums;

namespace Clinic.Api.DTOs.PatientDto;

/// <summary>
/// DTO for updating an existing patient, including optional personal information,
/// medical history, and contact details.
/// </summary>
public class UpdatePatientDto
{
    public string? FirstName { get; set; } = null;
    public string? LastName { get; set; } = null;
    public string? Patronymic { get; set; } = null;
    public DateTime? DateOfBirth { get; set; } = null;
    public string? Address { get; set; } = null;
    public string? PhoneNumber { get; set; } = null;
    public BloodGroup? BloodGroup { get; set; } = null;
    public RhesusFactor? RhesusFactor { get; set; } = null;
}