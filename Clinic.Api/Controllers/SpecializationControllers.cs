using Microsoft.AspNetCore.Mvc;
using Clinic.Api.Services;
using Clinic.Api.DTOs.SpecializationDto;

namespace Clinic.Api.Controllers;

/// <summary>
/// Controller for managing specialization operations such as retrieving,
/// creating, and deleting specializations.
/// </summary>
[ApiController]
[Route("api/specializations")]
public class SpecializationControllers : ControllerBase
{  
    private readonly SpecializationServices _specializationServices;

    /// <summary>
    /// Initializes a new instance of <see cref="SpecializationControllers"/>.
    /// </summary>
    /// <param name="specializationServices">Service for specialization operations.</param>
    public SpecializationControllers(SpecializationServices specializationServices)
    {
        _specializationServices = specializationServices;
    }

    /// <summary>
    /// Retrieves all specializations.
    /// </summary>
    /// <returns>A list of all specializations.</returns>
    [HttpGet("GetAllSpecializations")]
    public IActionResult GetAll()
    {
        var specializations = _specializationServices.GetAllSpecializations();
        return Ok(specializations);
    }

    /// <summary>
    /// Creates a new specialization.
    /// </summary>
    /// <param name="createSpecializationDto">The details of the specialization to create.</param>
    /// <returns>The created specialization or a BadRequest if it already exists.</returns>
    [HttpPost("CreateSpecialization")]
    public IActionResult Create(CreateSpecializationDto createSpecializationDto)
    {
        var result = _specializationServices.CreateSpecialization(createSpecializationDto);
        if (result == null)
        {
            return BadRequest("The specialization already exists.");
        }
        return Ok(result);
    }

    /// <summary>
    /// Gets a specialization by its id.
    /// </summary>
    /// <param name="id">The id of the specialization to retrieve.</param>
    /// <returns>The specialization if found, otherwise NotFound.</returns>
    [HttpGet("GetSpecialization/{id}")]
    public IActionResult Get(int id)
    {
        var specialization = _specializationServices.GetSpecialization(id);
        if (specialization == null)
        {
            return NotFound("Specialization not found.");
        }
        return Ok(specialization);
    }

    /// <summary>
    /// Deletes a specialization by its id.
    /// </summary>
    /// <param name="id">The id of the specialization to delete.</param>
    /// <returns>A confirmation message or NotFound if the specialization does not exist.</returns>
    [HttpDelete("DeleteSpecialization/{id}")]
    public IActionResult Delete(int id)
    {
        var result = _specializationServices.DeleteSpecialization(id);
        if (!result)
        {
            return NotFound("Specialization not found.");
        }
        return Ok("Specialization deleted successfully.");
    }
}
