using Microsoft.AspNetCore.Mvc;
using Clinic.Application.DTOs.Patient;
using Clinic.Application.Interfaces.Services;

namespace Clinic.Api.Controllers;

/// <summary>
/// Controller for managing patient operations such as retrieving,
/// creating, updating, and deleting patient records.
/// </summary>
[ApiController]
[Route("api/patients")]
public class PatientControllers(IPatientServices patientServices) : BaseControllers<GetPatientDto, CreateUpdatePatientDto>(patientServices);
