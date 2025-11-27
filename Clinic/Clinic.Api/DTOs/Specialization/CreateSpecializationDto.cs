using System.ComponentModel.DataAnnotations;

namespace Clinic.Api.DTOs.SpecializationDto;

/// <summary>
/// DTO for creating a new specialization, including required name.
/// </summary>
public class CreateSpecializationDto
{
    [Required]public string Name { get; set; } = null!;
}