using Microsoft.AspNetCore.Mvc;
using Clinic.Api.DTOs.Appointment;

namespace Clinic.Api.Interfaces.Controllers;

/// <summary>
/// Interface for appointment controller operations.
/// Extends the base controller interface with appointment-specific methods.
/// </summary>
public interface IAppointmentController : IBaseController<GetAppointmentDto, CreateAppointmentDto, UpdateAppointmentDto>
{
    /// <summary>
    /// Gets all appointments for a specific doctor.
    /// </summary>
    /// <param name="doctorId">The doctor's id.</param>
    /// <returns>ActionResult containing appointments or NotFound if doctor not found.</returns>
    public IActionResult GetByDoctor(int doctorId);

    /// <summary>
    /// Gets all appointments for a specific patient.
    /// </summary>
    /// <param name="patientId">The patient's id.</param>
    /// <returns>ActionResult containing appointments or NotFound if patient not found.</returns>
    public IActionResult GetByPatient(int patientId);
}

