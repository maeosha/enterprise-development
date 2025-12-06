using Microsoft.AspNetCore.Mvc;
using Clinic.Api.DTOs.SpecializationDto;
using Clinic.Api.Interfaces.Controllers;
using Clinic.Api.Interfaces.Services;

namespace Clinic.Api.Controllers;

/// <summary>
/// Controller for managing specialization operations such as retrieving,
/// creating, and deleting specializations.
/// </summary>
[ApiController]
[Route("api/specializations")]
public class SpecializationControllers : BaseControllers<GetSpecializationDto, CreateSpecializationDto, UpdateSpecializationDto, ISpecializationServices>, ISpecializationController
{
    /// <summary>
    /// Initializes a new instance of <see cref="SpecializationControllers"/>.
    /// </summary>
    /// <param name="service">Service for specialization operations.</param>
    public SpecializationControllers(ISpecializationServices service) : base(service)
    {
    }
}
