using Microsoft.AspNetCore.Mvc;
using Clinic.Application.Interfaces.Services;
using Clinic.Application.DTOs.Appointment;

namespace Clinic.Api.Controllers;

/// <summary>
/// Controller for handling appointment-related operations such as retrieving, creating, updating,
/// and deleting appointments in the clinic.
/// </summary>
[ApiController]
[Route("api/appointments")]
public class AppointmentControllers(IAppointmentServices appointmentServices) : BaseControllers<GetAppointmentDto, CreateUpdateAppointmentDto>(appointmentServices)
{
    /// <summary>
    /// Gets all appointments for a specific doctor.
    /// </summary>
    /// <param name="doctorId">The doctor's id.</param>
    /// <returns>ActionResult containing appointments or NotFound if doctor not found.</returns>
    [HttpGet("doctor/{doctorId}")]
    [ProducesResponseType(typeof(IEnumerable<GetAppointmentDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<IEnumerable<GetAppointmentDto>> GetByDoctor(int doctorId)
    {
        var appointments = appointmentServices.GetAppointmentsByDoctor(doctorId);
        if (appointments == null)
        {
            return NotFound("Doctor not found.");
        }
        return Ok(appointments);
    }

    /// <summary>
    /// Gets all appointments for a specific patient.
    /// </summary>
    /// <param name="patientId">The patient's id.</param>
    /// <returns>ActionResult containing appointments or NotFound if patient not found.</returns>
    [HttpGet("patient/{patientId}")]
    [ProducesResponseType(typeof(IEnumerable<GetAppointmentDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<IEnumerable<GetAppointmentDto>> GetByPatient(int patientId)
    {
        var appointments = appointmentServices.GetAppointmentsByPatient(patientId);
        if (appointments == null)
        {
            return NotFound("Patient not found.");
        }
        return Ok(appointments);
    }
}
