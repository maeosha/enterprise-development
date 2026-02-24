using Clinic.Application.DTOs.Specialization;

namespace Clinic.Application.DTOs.Doctor;

/// <summary>
/// DTO for creating a new doctor, including required personal information,
/// specialization list, and experience years.
/// </summary>
public class CreateUpdateDoctorDto
{
    /// <summary>
    /// Required: The passport number of the doctor.
    /// </summary>
    public required string PassportNumber { get; set; }

    /// <summary>
    /// Required: The birth date of the doctor.
    /// </summary>
    public required DateOnly BirthDate { get; set; }

    /// <summary>
    /// Required: The last name of the doctor.
    /// </summary>
    public required string LastName { get; set; }

    /// <summary>
    /// Required: The first name of the doctor.
    /// </summary>
    public required string FirstName { get; set; }

    /// <summary>
    /// Required: The phone number of the doctor.
    /// </summary>
    public required string PhoneNumber { get; set; }

    /// <summary>
    /// Optional: The patronymic (middle name) of the doctor.
    /// </summary>
    public string? Patronymic { get; set; }

    /// <summary>
    /// Required: The gender of the doctor.
    /// </summary>
    public required String Gender { get; set; }

    /// <summary>
    /// Required: The list of specializations for the doctor.
    /// </summary>
    public required List<CreateUpdateSpecializationDto> Specializations { get; set; }

    /// <summary>
    /// Required: The number of years of experience for the doctor.
    /// </summary>
    public required int ExperienceYears { get; set; }
}