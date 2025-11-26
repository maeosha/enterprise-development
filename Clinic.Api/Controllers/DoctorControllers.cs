using Microsoft.AspNetCore.Mvc;
using Clinic.Api.Services;
using Clinic.Api.DTOs.DoctorDto;

namespace Clinic.Api.Controllers;

/// <summary>
/// Controller for handling doctor-related operations such as retrieving,
/// creating, updating, and deleting doctors in the clinic.
/// </summary>
[ApiController]
[Route("api/doctors")]
public class DoctorControllers : ControllerBase
{  
    private readonly DoctorServices _doctorServices;

    /// <summary>
    /// Initializes a new instance of <see cref="DoctorControllers"/>.
    /// </summary>
    /// <param name="doctorServices">Service for doctor operations.</param>
    public DoctorControllers(DoctorServices doctorServices)
    {
        _doctorServices = doctorServices;
    }

    /// <summary>
    /// Gets all doctors.
    /// </summary>
    [HttpGet("GetAllDoctors")]
    public IActionResult GetAll()
    {
        var doctors = _doctorServices.GetAllDoctors();
        return Ok(doctors);
    }

    /// <summary>
    /// Creates a new doctor.
    /// </summary>
    /// <param name="createDoctorDto">The doctor creation data.</param>
    [HttpPost("AddDoctor")]
    public IActionResult Create([FromBody] CreateDoctorDto createDoctorDto)
    {
        var doctor = _doctorServices.CreateDoctor(createDoctorDto);
        if (doctor == null)
        {
            return BadRequest("The doctor already exists.");
        }
        return Ok(doctor);
    }

    /// <summary>
    /// Gets details of a specific doctor by their id.
    /// </summary>
    /// <param name="id">The id of the doctor.</param>
    [HttpGet("GetDoctor/{id}")]
    public IActionResult Get(int id)
    {
        var doctor = _doctorServices.GetDoctor(id);
        if (doctor == null)
        {
            return NotFound("Doctor not found.");
        }
        return Ok(doctor);
    }

    /// <summary>
    /// Updates an existing doctor's information.
    /// </summary>
    /// <param name="id">The id of the doctor to update.</param>
    /// <param name="updateDoctorDto">The update information.</param>
    [HttpPut("UpdateDoctor/{id}")]
    public IActionResult Update(int id, UpdateDoctorDto updateDoctorDto)
    {
        var doctor = _doctorServices.UpdateDoctor(id, updateDoctorDto);
        if (doctor == null)
        {
            return NotFound("Doctor not found.");
        }
        return Ok(doctor);
    }

    /// <summary>
    /// Deletes a doctor.
    /// </summary>
    /// <param name="id">Id of the doctor to delete.</param>
    [HttpDelete("DeleteDoctor/{id}")]
    public IActionResult Delete(int id)
    {
        var result = _doctorServices.DeleteDoctor(id);
        if (!result)
        {
            return NotFound("Doctor not found.");
        }
        return Ok("Doctor deleted successfully.");
    }

}