namespace Clinic.Api.DTOs.Specialization;

/// <summary>
/// DTO for creating a new specialization, including required name.
/// </summary>
public class CreateSpecializationDto
{
    /// <summary>
    /// The name of the specialization to create.
    /// </summary>
    public required string Name { get; set; }
}