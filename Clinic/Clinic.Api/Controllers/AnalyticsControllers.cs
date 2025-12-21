using Microsoft.AspNetCore.Mvc;
using Clinic.Api.Services;
using Clinic.Api.DTOs.DoctorDto;
using Clinic.Api.DTOs.PatientDto;
using Clinic.Api.DTOs.Appointment;

namespace Clinic.Api.Controllers;

/// <summary>
/// Controller for analytics and business logic queries about doctors, patients, and appointments.
/// </summary>
[ApiController]
[Route("api/analytics")]
public class AnalyticsController(AnalyticsServices testServices) : ControllerBase
{
    /// <summary>
    /// Retrieves a list of doctors with 10 or more years of experience.
    /// Returns a 200 OK with a list of GetDoctorDto objects.
    /// </summary>
    [HttpGet("doctors/experience")]
    [ProducesResponseType(typeof(IReadOnlyList<GetDoctorDto>), StatusCodes.Status200OK)]
    public ActionResult<IReadOnlyList<GetDoctorDto>> GetDoctorsWithExperience()
    {
        return Ok(testServices.GetDoctorsWithExperience10YearsOrMore());
    }

    /// <summary>
    /// Fetches patients assigned to a specific doctor (by doctorId), ordered by their full name.
    /// Returns 200 OK with a list of GetPatientDto objects if the doctor exists; otherwise, 404 Not Found with a message.
    /// </summary>
    [HttpGet("patients/doctor")]
    [ProducesResponseType(typeof(IReadOnlyList<GetPatientDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<IReadOnlyList<GetPatientDto>> GetPatientsByDoctor(int doctorId)
    {
        var result = testServices.GetPatientsByDoctorOrderedByFullName(doctorId);
        if (result == null)
        {
            return NotFound("Doctor not found.");
        }
        return Ok(result);
    }

    /// <summary>
    /// Returns the count of return visits (as an integer) that occurred in the last month.
    /// Responds with 200 OK.
    /// </summary>
    [HttpGet("patients/return-visits")]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    public ActionResult<int> GetReturnVisitsCountLastMonth()
    {
        return Ok(testServices.GetReturnVisitsCountLastMonth());
    }

    /// <summary>
    /// Gets a list of patients over 30 years old who are associated with multiple doctors, ordered by birth date.
    /// Returns 200 OK with a list of GetPatientDto objects.
    /// </summary>
    [HttpGet("patients/over-30")]
    [ProducesResponseType(typeof(IReadOnlyList<GetPatientDto>), StatusCodes.Status200OK)]
    public ActionResult<IReadOnlyList<GetPatientDto>> GetPatientsOver30WithMultipleDoctors()
    {
        return Ok(testServices.GetPatientsOver30WithMultipleDoctorsOrderedByBirthDate());
    }

    /// <summary>
    /// Retrieves appointments scheduled in a specific room (roomNumber) for the current month.
    /// Returns 200 OK with a list of GetAppointmentDto objects.
    /// </summary>
    [HttpGet("appointments/room")]
    [ProducesResponseType(typeof(IReadOnlyList<GetAppointmentDto>), StatusCodes.Status200OK)]
    public ActionResult<IReadOnlyList<GetAppointmentDto>> GetAppointmentsInRoomForCurrentMonth(int roomNumber)
    {
        return Ok(testServices.GetAppointmentsInRoomForCurrentMonth(roomNumber));
    }
}