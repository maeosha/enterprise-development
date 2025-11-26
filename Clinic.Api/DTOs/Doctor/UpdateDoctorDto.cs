using Clinic.Models.Entities;
using Clinic.Models.Enums;

namespace Clinic.Api.DTOs.DoctorDto;

/// <summary>
/// DTO for updating an existing doctor, including optional personal information,
/// specialization list, and experience years.
/// </summary>
public class UpdateDoctorDto
{
    public string? PassportNumber { get; set; }
    public DateOnly? BirthDate { get; set; }
    public string? LastName { get; set; }
    public string? FirstName { get; set; }
    public string? Patronymic { get; set; }
    public Gender? Gender { get; set; }
    public List<Specialization>? Specializations { get; set; } = null;
    public int? ExperienceYears { get; set; }
}