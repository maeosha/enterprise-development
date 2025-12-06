using Microsoft.AspNetCore.Mvc;
using Clinic.Api.Services;
using Clinic.Api.DTOs.DoctorDto;
using Clinic.Api.Interfaces.Controllers;
using Clinic.Api.Interfaces.Services;

namespace Clinic.Api.Controllers;

/// <summary>
/// Controller for handling doctor-related operations such as retrieving,
/// creating, updating, and deleting doctors in the clinic.
/// </summary>
[ApiController]
[Route("api/doctors")]
public class DoctorControllers : BaseControllers<GetDoctorDto, CreateDoctorDto, UpdateDoctorDto, IDoctorServices>, IDoctorController
{
    /// <summary>
    /// Initializes a new instance of <see cref="DoctorControllers"/>.
    /// </summary>
    /// <param name="service">Service for doctor operations.</param>
    public DoctorControllers(IDoctorServices service) : base(service)
    {
    }
}