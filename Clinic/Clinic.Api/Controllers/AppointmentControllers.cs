using Microsoft.AspNetCore.Mvc;
using Clinic.Api.Interfaces.Controllers;
using Clinic.Api.Interfaces.Services;
using Clinic.Api.DTOs.Appointment;

namespace Clinic.Api.Controllers;

/// <summary>
/// Controller for handling appointment-related operations such as retrieving, creating, updating,
/// and deleting appointments in the clinic.
/// </summary>
[ApiController]
[Route("api/appointments")]
public class AppointmentControllers : BaseControllers<GetAppointmentDto, CreateAppointmentDto, UpdateAppointmentDto, IAppointmentServices>, IAppointmentController
{
    private readonly IAppointmentServices _appointmentServices;

    /// <summary>
    /// Initializes a new instance of <see cref="AppointmentControllers"/>.
    /// </summary>
    /// <param name="service">Service for appointment operations.</param>
    public AppointmentControllers(IAppointmentServices service) : base(service)
    {
        _appointmentServices = service;
    }

    /// <summary>
    /// Gets all appointments for a specific doctor.
    /// </summary>
    /// <param name="doctorId">The doctor's id.</param>
    /// <returns>ActionResult containing appointments or NotFound if doctor not found.</returns>
    [HttpGet("doctor/{doctorId}")]
    public IActionResult GetByDoctor(int doctorId)
    {
        var appointments = _appointmentServices.GetAppointmentsByDoctor(doctorId);
        return Ok(appointments);
    }

    /// <summary>
    /// Gets all appointments for a specific patient.
    /// </summary>
    /// <param name="patientId">The patient's id.</param>
    /// <returns>ActionResult containing appointments or NotFound if patient not found.</returns>
    [HttpGet("patient/{patientId}")]
    public IActionResult GetByPatient(int patientId)
    {
        var appointments = _appointmentServices.GetAppointmentsByPatient(patientId);
        return Ok(appointments);
    }
}
