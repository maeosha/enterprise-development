using Microsoft.AspNetCore.Mvc;
using Clinic.Api.DTOs.Specialization;
using Clinic.Api.Interfaces.Services;

namespace Clinic.Api.Controllers;

/// <summary>
/// Controller for managing specialization operations such as retrieving,
/// creating, and deleting specializations.
/// </summary>
[ApiController]
[Route("api/specializations")]
public class SpecializationControllers(ISpecializationServices specializationServices) : BaseControllers<GetSpecializationDto, CreateSpecializationDto, UpdateSpecializationDto>(specializationServices);
