using Clinic.Application.DTOs.Specialization;

namespace Clinic.Application.Interfaces.Services;

/// <summary>
/// Interface for specialization service operations.
/// Provides methods for managing specializations in the clinic system.
/// Note: Specializations do not support update operations.
/// </summary>
public interface ISpecializationServices : IBaseServices<GetSpecializationDto, CreateUpdateSpecializationDto>;
