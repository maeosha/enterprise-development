using Clinic.Api.DTOs.PatientDto;

namespace Clinic.Api.Interfaces.Controllers;

/// <summary>
/// Interface for patient controller operations.
/// </summary>
public interface IPatientController : IBaseController<GetPatientDto, CreatePatientDto, UpdatePatientDto>
{
}

