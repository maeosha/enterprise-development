namespace Clinic.Api.DTOs.Specialization;

/// <summary>
/// DTO for updating an existing specialization.
/// Note: Currently not used as specializations do not support update operations.
/// </summary>
public class UpdateSpecializationDto
{
    /// <summary>
    /// The new name of the specialization. Optional.
    /// </summary>
    public string? Name { get; set; }
}

