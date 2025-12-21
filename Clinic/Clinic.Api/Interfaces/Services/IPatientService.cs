using Clinic.Api.DTOs.Patient;

namespace Clinic.Api.Interfaces.Services;

/// <summary>
/// Interface for patient service operations.
/// Provides methods for managing patients in the clinic system.
/// </summary>
public interface IPatientServices : IBaseServices<GetPatientDto, CreatePatientDto, UpdatePatientDto>
{
}