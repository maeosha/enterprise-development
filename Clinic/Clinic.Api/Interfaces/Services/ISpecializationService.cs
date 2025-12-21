using Clinic.Api.DTOs.Specialization;

namespace Clinic.Api.Interfaces.Services;

/// <summary>
/// Interface for specialization service operations.
/// Provides methods for managing specializations in the clinic system.
/// Note: Specializations do not support update operations.
/// </summary>
public interface ISpecializationServices : IBaseServices<GetSpecializationDto, CreateSpecializationDto, UpdateSpecializationDto>
{
}

