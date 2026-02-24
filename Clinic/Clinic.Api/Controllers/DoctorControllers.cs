using Microsoft.AspNetCore.Mvc;
using Clinic.Application.DTOs.Doctor;
using Clinic.Application.Interfaces.Services;

namespace Clinic.Api.Controllers;

/// <summary>
/// Controller for handling doctor-related operations such as retrieving,
/// creating, updating, and deleting doctors in the clinic.
/// </summary>
[ApiController]
[Route("api/doctors")]
public class DoctorControllers(IDoctorServices doctorServices) : BaseControllers<GetDoctorDto, CreateUpdateDoctorDto>(doctorServices);
