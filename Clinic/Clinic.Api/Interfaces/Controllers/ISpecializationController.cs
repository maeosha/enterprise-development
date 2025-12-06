using Clinic.Api.DTOs.SpecializationDto;

namespace Clinic.Api.Interfaces.Controllers;

/// <summary>
/// Interface for specialization controller operations.
/// </summary>
public interface ISpecializationController : IBaseController<GetSpecializationDto, CreateSpecializationDto, UpdateSpecializationDto>
{
}

