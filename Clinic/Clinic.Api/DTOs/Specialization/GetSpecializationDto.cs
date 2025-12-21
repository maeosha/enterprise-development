namespace Clinic.Api.DTOs.SpecializationDto;

/// <summary>
/// DTO for retrieving detailed information about a specialization,
/// including its unique identifier and name.
/// </summary>
public class GetSpecializationDto
{
    /// <summary>
    /// The unique identifier of the specialization.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The name of the specialization.
    /// </summary>
    public string Name { get; set; } = null!;
}