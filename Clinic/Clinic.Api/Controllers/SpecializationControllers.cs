using Microsoft.AspNetCore.Mvc;
using Clinic.Application.DTOs.Specialization;
using Clinic.Application.Interfaces.Services;

namespace Clinic.Api.Controllers;

/// <summary>
/// Controller for managing specialization operations such as retrieving,
/// creating, and deleting specializations.
/// </summary>
[ApiController]
[Route("api/specializations")]
public class SpecializationControllers(ISpecializationServices specializationServices) : BaseControllers<GetSpecializationDto, CreateUpdateSpecializationDto>(specializationServices);
