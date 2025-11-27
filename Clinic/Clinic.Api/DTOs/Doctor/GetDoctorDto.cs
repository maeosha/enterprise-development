using Clinic.Models.Entities;
namespace Clinic.Api.DTOs.DoctorDto;

/// <summary>
/// DTO for retrieving detailed information about a doctor,
/// including personal details, specialization list, and experience years.
/// </summary>
public class GetDoctorDto
{
    public int Id { get; set; }
    public string PassportNumber { get; set; } = string.Empty;
    public DateOnly BirthDate { get; set; }
    public string LastName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string? Patronymic { get; set; }
    public String Gender { get; set; } = null!;
    public List<String> Specializations { get; set; } = new();
    public int ExperienceYears { get; set; }
}