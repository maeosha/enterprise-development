using Clinic.Application.DTOs.Patient;

namespace Clinic.Application.Interfaces.Services;

/// <summary>
/// Interface for patient service operations.
/// Provides methods for managing patients in the clinic system.
/// </summary>
public interface IPatientServices : IBaseServices<GetPatientDto, CreateUpdatePatientDto>;
