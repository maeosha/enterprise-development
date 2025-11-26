using Microsoft.AspNetCore.Mvc;
using Clinic.Api.Services;
using Clinic.Api.DTOs.PatientDto;

namespace Clinic.Api.Controllers;

/// <summary>
/// Controller for managing patient operations such as retrieving,
/// creating, updating, and deleting patient records.
/// </summary>
[ApiController]
[Route("api/patients")]
public class PatientControllers : ControllerBase
{
    private readonly PatientServices _patientServices;

    /// <summary>
    /// Constructor for PatientControllers.
    /// </summary>
    /// <param name="patientServices">The service to manage patient data.</param>
    public PatientControllers(PatientServices patientServices)
    {
        _patientServices = patientServices;
    }

    /// <summary>
    /// Retrieves all patients from the database.
    /// </summary>
    /// <returns>A list of all patients.</returns>
    [HttpGet("GetAllPatients")]
    public IActionResult GetAll()
    {
        var patients = _patientServices.GetAllPatients();
        return Ok(patients);
    }

    /// <summary>
    /// Creates a new patient record.
    /// </summary>
    /// <param name="dto">The patient data to create.</param>
    /// <returns>The created patient or a BadRequest if creation fails.</returns>
    [HttpPost("CreatePatient")]
    public IActionResult Create(CreatePatientDto dto)
    {
        var result = _patientServices.CreatePatient(dto);
        if (result == null)
        {
            return BadRequest("Could not create patient.");
        }
        return Ok(result);
    }

    /// <summary>
    /// Retrieves a patient by their unique ID.
    /// </summary>
    /// <param name="id">The ID of the patient to retrieve.</param>
    /// <returns>The patient record or NotFound if the patient does not exist.</returns>
    [HttpGet("GetPatient/{id}")]
    public IActionResult Get(int id)
    {
        var patient = _patientServices.GetPatient(id);
        if (patient == null)
        {
            return NotFound("Patient not found.");
        }
        return Ok(patient);
    }

    /// <summary>
    /// Updates an existing patient record.
    /// </summary>
    /// <param name="id">The ID of the patient to update.</param>
    /// <param name="dto">The updated patient data.</param>
    /// <returns>The updated patient or NotFound if the patient does not exist.</returns>
    [HttpPut("UpdatePatient/{id}")]
    public IActionResult Update(int id, UpdatePatientDto dto)
    {
        var result = _patientServices.UpdatePatient(id, dto);
        if (result == null)
        {
            return NotFound("Patient not found.");
        }
        return Ok(result);
    }

    /// <summary>
    /// Deletes a patient by their unique ID.
    /// </summary>
    /// <param name="id">The ID of the patient to delete.</param>
    /// <returns>Ok if deletion was successful; NotFound otherwise.</returns>
    [HttpDelete("DeletePatient/{id}")]
    public IActionResult Delete(int id)
    {
        var result = _patientServices.DeletePatient(id);
        if (!result)
        {
            return NotFound();
        }
        return Ok("Patient deleted successfully.");
    }
}