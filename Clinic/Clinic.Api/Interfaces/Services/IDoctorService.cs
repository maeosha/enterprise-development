using Clinic.Api.DTOs.DoctorDto;

namespace Clinic.Api.Interfaces.Services;

/// <summary>
/// Interface for doctor service operations.
/// Provides methods for managing doctors in the clinic system.
/// </summary>
public interface IDoctorServices : IBaseServices<GetDoctorDto, CreateDoctorDto, UpdateDoctorDto>
{
}

