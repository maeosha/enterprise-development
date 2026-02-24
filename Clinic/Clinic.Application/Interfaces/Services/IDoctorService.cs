using Clinic.Application.DTOs.Doctor;

namespace Clinic.Application.Interfaces.Services;

/// <summary>
/// Interface for doctor service operations.
/// Provides methods for managing doctors in the clinic system.
/// </summary>
public interface IDoctorServices : IBaseServices<GetDoctorDto, CreateUpdateDoctorDto>;
