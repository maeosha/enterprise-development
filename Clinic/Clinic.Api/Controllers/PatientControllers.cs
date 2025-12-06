using Microsoft.AspNetCore.Mvc;
using Clinic.Api.DTOs.PatientDto;
using Clinic.Api.Interfaces.Controllers;
using Clinic.Api.Interfaces.Services;

namespace Clinic.Api.Controllers;

/// <summary>
/// Controller for managing patient operations such as retrieving,
/// creating, updating, and deleting patient records.
/// </summary>
[ApiController]
[Route("api/patients")]
public class PatientControllers : BaseControllers<GetPatientDto, CreatePatientDto, UpdatePatientDto, IPatientServices>
{
    /// <summary>
    /// Initializes a new instance of <see cref="PatientControllers"/>.
    /// </summary>
    /// <param name="service">Service for patient operations.</param>
    public PatientControllers(IPatientServices service) : base(service)
    {
    }
}