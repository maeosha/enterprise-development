namespace Clinic.Api.DTOs.SpecializationDto;

/// <summary>
/// DTO for retrieving detailed information about a specialization,
/// including its unique identifier and name.
/// </summary>
public class GetSpecializationDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}