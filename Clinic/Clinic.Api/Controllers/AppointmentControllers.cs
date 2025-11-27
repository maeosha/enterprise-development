using Microsoft.AspNetCore.Mvc;
using Clinic.Api.Services;
using Clinic.Api.DTOs.Appointment;

namespace Clinic.Api.Controllers;

[ApiController]
[Route("api/appointments")]
/// <summary>
/// Controller for handling appointment-related operations such as retrieving, creating, updating,
/// and deleting appointments in the clinic.
/// </summary>
public class AppointmentControllers : ControllerBase
{
    private readonly AppointmentServices _appointmentServices;

    /// <summary>
    /// Initializes a new instance of <see cref="AppointmentControllers"/>.
    /// </summary>
    /// <param name="appointmentServices">Service for appointment operations.</param>
    public AppointmentControllers(AppointmentServices appointmentServices)
    {
        _appointmentServices = appointmentServices;
    }

    /// <summary>
    /// Gets all appointments.
    /// </summary>
    [HttpGet("GetAllAppointments")]
    public IActionResult GetAll()
    {
        var appointments = _appointmentServices.GetAllAppointments();
        return Ok(appointments);
    }

    /// <summary>
    /// Gets details of a specific appointment by its id.
    /// </summary>
    /// <param name="id">The id of the appointment.</param>
    [HttpGet("GetAppointment/{id}")]
    public IActionResult Get(int id)
    {
        var appointment = _appointmentServices.GetAppointment(id);
        if (appointment == null)
        {
            return NotFound("Appointment not found.");
        }
        return Ok(appointment);
    }

    /// <summary>
    /// Gets all appointments for a specific doctor.
    /// </summary>
    /// <param name="doctorId">The doctor's id.</param>
    [HttpGet("GetAppointmentsByDoctor/{doctorId}")]
    public IActionResult GetByDoctor(int doctorId)
    {
        var appointments = _appointmentServices.GetAppointmentsByDoctor(doctorId);
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
    [HttpGet("GetAppointmentsByPatient/{patientId}")]
    public IActionResult GetByPatient(int patientId)
    {
        var appointments = _appointmentServices.GetAppointmentsByPatient(patientId);
        if (appointments == null)
        {
            return NotFound("Patient not found.");
        }
        return Ok(appointments);
    }

    /// <summary>
    /// Creates a new appointment.
    /// </summary>
    /// <param name="dto">The appointment creation information.</param>
    [HttpPost("CreateAppointment")]
    public IActionResult Create([FromBody] CreateAppointmentDto dto)
    {
        var appointment = _appointmentServices.CreateAppointment(dto);
        if (appointment == null)
        {
            return BadRequest("Could not create appointment (doctor or patient may not exist).");
        }
        return Ok(appointment);
    }

    /// <summary>
    /// Updates an existing appointment.
    /// </summary>
    /// <param name="id">The id of the appointment to update.</param>
    /// <param name="dto">The update information.</param>
    [HttpPut("UpdateAppointment/{id}")]
    public IActionResult Update(int id, [FromBody] UpdateAppointmentDto dto)
    {
        var appointment = _appointmentServices.UpdateAppointment(id, dto);
        if (appointment == null)
        {
            return NotFound("Appointment not found.");
        }
        return Ok(appointment);
    }

    /// <summary>
    /// Deletes an appointment.
    /// </summary>
    /// <param name="id">Id of the appointment to delete.</param>
    [HttpDelete("DeleteAppointment/{id}")]
    public IActionResult Delete(int id)
    {
        var result = _appointmentServices.DeleteAppointment(id);
        if (!result)
        {
            return NotFound("Appointment not found.");
        }
        return Ok("Appointment deleted successfully.");
    }
}
