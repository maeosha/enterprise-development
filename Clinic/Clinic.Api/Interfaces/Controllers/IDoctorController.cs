using Clinic.Api.DTOs.DoctorDto;

namespace Clinic.Api.Interfaces.Controllers;

/// <summary>
/// Interface for doctor controller operations.
/// </summary>
public interface IDoctorController : IBaseController<GetDoctorDto, CreateDoctorDto, UpdateDoctorDto>
{
}

