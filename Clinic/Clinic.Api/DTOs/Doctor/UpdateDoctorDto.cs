using Clinic.Models.Entities;
using Clinic.Models.Enums;

namespace Clinic.Api.DTOs.DoctorDto;

/// <summary>
/// DTO for updating an existing doctor, including optional personal information,
/// specialization list, and experience years.
/// </summary>
public class UpdateDoctorDto
{
    /// <summary>
    /// The unique identifier of the doctor.
    /// </summary>
    public int? Id { get; set; }

    /// <summary>
    /// The passport number of the doctor.
    /// </summary>
    public string? PassportNumber { get; set; } = string.Empty;

    /// <summary>
    /// The birth date of the doctor.
    /// </summary>
    public DateOnly? BirthDate { get; set; }

    /// <summary>
    /// The last name of the doctor.
    /// </summary>
    public string? LastName { get; set; } = string.Empty;

    /// <summary>
    /// The first name of the doctor.
    /// </summary>
    public string? FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Optional: The patronymic (middle name) of the doctor.
    /// </summary>
    public string? Patronymic { get; set; }

    /// <summary>
    /// The gender of the doctor.
    /// </summary>
    public String? Gender { get; set; } = null!;

    /// <summary>
    /// The list of specializations for the doctor.
    /// </summary>
    public List<String>? Specializations { get; set; } = null!;

    /// <summary>
    /// The number of years of experience for the doctor.
    /// </summary>
    public int? ExperienceYears { get; set; } = null!;
}