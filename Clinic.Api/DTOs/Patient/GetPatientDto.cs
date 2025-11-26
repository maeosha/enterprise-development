using Clinic.Models.Enums;

namespace Clinic.Api.DTOs.PatientDto;

/// <summary>
/// DTO for retrieving detailed information about a patient,
/// including personal details, medical history, and contact details.
/// </summary>
public class GetPatientDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Patronymic { get; set; }
    public DateOnly BirthDate { get; set; }
    public String Gender { get; set; } = null!;
    public String BloodGroup { get; set; } = null!;
    public String RhesusFactor { get; set; } = null!;
}