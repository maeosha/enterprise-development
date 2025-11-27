using Microsoft.AspNetCore.Mvc;
using Clinic.Api.Services;

[ApiController]
[Route("api/[controller]")]
public class TestControllers : ControllerBase
{
    private readonly TestServices _testServices;

    public TestControllers(TestServices testServices)
    {
        _testServices = testServices;
    }

    [HttpGet("doctors/experience")]
    public IActionResult GetDoctorsWithExperience()
    {
        return Ok(_testServices.GetDoctorsWithExperience10YearsOrMore());
    }

    [HttpGet("patients/doctor")]
    public IActionResult GetPatientsByDoctor(int doctorId)
    {
        return Ok(_testServices.GetPatientsByDoctorOrderedByFullName(doctorId));
    }

    [HttpGet("patients/return-visits")]
    public IActionResult GetReturnVisitsCountLastMonth()
    {
        return Ok(_testServices.GetReturnVisitsCountLastMonth());
    }

    [HttpGet("patients/over-30")]
    public IActionResult GetPatientsOver30WithMultipleDoctors()
    {
        return Ok(_testServices.GetPatientsOver30WithMultipleDoctorsOrderedByBirthDate());
    }

    [HttpGet("appointments/room")]
    public IActionResult GetAppointmentsInRoomForCurrentMonth(int roomNumber)
    {
        return Ok(_testServices.GetAppointmentsInRoomForCurrentMonth(roomNumber));
    }
}