using System.ComponentModel.DataAnnotations;
using Clinic.Models.Entities;

namespace Clinic.Api.DTOs.DoctorDto;

/// <summary>
/// DTO for creating a new doctor, including required personal information,
/// specialization list, and experience years.
/// </summary>
public class CreateDoctorDto
{
    [Required]public string PassportNumber { get; set; } = null!;
    [Required]public DateOnly BirthDate { get; set; }
    [Required]public string LastName { get; set; } = null!;
    [Required]public string FirstName { get; set; } = null!;
    [Required]public string PhoneNumber { get; set; } = null!;
    public string? Patronymic { get; set; }
    [Required]public String Gender { get; set; } = null!;
    [Required]public List<Specialization> Specializations { get; set; } = null!;
    [Required]public int ExperienceYears { get; set; }
}
