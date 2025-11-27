using System.ComponentModel.DataAnnotations;

namespace Clinic.Api.DTOs.PatientDto;

/// <summary>
/// DTO for creating a new patient, including required personal information,
/// medical history, and contact details.
/// </summary>
public class CreatePatientDto
{
    [Required]public string FirstName { get; set; } = null!;
    [Required]public string LastName { get; set; } = null!;
    public string? Patronymic { get; set; }
    [Required]public string PassportNumber { get; set; } = null!;
    [Required]public DateOnly BirthDate { get; set; }
    [Required]public String Gender { get; set; } = null!;
    [Required]public string Address { get; set; } = null!;
    [Required]public string PhoneNumber { get; set; } = null!;
    [Required]public String BloodGroup { get; set; } = null!;
    [Required]public String RhesusFactor { get; set; } = null!;
}