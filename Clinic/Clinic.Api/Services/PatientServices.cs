using AutoMapper;
using Clinic.Api.DataBase;
using Clinic.Api.DTOs.PatientDto;
using Clinic.Models.Entities;
using Clinic.Api.Interfaces.Services;

namespace Clinic.Api.Services;

/// <summary>
/// Service class for managing patient-related operations in the Clinic API.
/// Provides methods for creating, retrieving, updating, and deleting patients,
/// as well as listing all patients. Uses AutoMapper for entity-DTO mapping.
/// </summary>
public class PatientServices : IPatientServices
{
    private readonly IClinicDataBase _db;
    private readonly IMapper _mapper;
    private int _patientId;

    /// <summary>
    /// Initializes a new instance of the <see cref="PatientServices"/> class.
    /// Sets the initial patient identifier based on the count in the database.
    /// </summary>
    /// <param name="db">The database service for patient operations.</param>
    /// <param name="mapper">The AutoMapper instance for mapping objects.</param>
    public PatientServices(IClinicDataBase db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
        _patientId = _db.PatientCount() + 1;
    }

    /// <summary>
    /// Retrieves all patients from the database and maps them to DTOs.
    /// </summary>
    /// <returns>A collection of <see cref="GetPatientDto"/> representing all patients.</returns>
    public IReadOnlyCollection<GetPatientDto> GetAll()
    {
        var patients = _db.GetAllPatients();
        var patientsDto = _mapper.Map<IReadOnlyCollection<GetPatientDto>>(patients);
        return patientsDto;
    }

    /// <summary>
    /// Creates a new patient entity in the database.
    /// </summary>
    /// <param name="patientCreateDto">The DTO containing patient creation data.</param>
    /// <returns>The created patient as a <see cref="GetPatientDto"/> if successful; otherwise, null.</returns>
    public GetPatientDto? Create(CreatePatientDto patientCreateDto)
    {
        var patient = _mapper.Map<Patient>(patientCreateDto);
        patient.Id = _patientId;
        if (!_db.AddPatient(patient))
        {
            return null;
        }
        _patientId++;
        var patientGetDto = _mapper.Map<GetPatientDto>(patient);
        return patientGetDto;
    }

    /// <summary>
    /// Updates an existing patient with the given id using the provided update DTO.
    /// </summary>
    /// <param name="id">The identifier of the patient to update.</param>
    /// <param name="patientUpdateDto">The DTO containing updated patient data.</param>
    /// <returns>The updated patient as a <see cref="GetPatientDto"/> if successful; otherwise, null.</returns>
    public GetPatientDto? Update(int id, UpdatePatientDto patientUpdateDto)
    {
        var patient = _db.GetPatient(id);
        if (patient == null)
        {
            return null;
        }
        _mapper.Map(patientUpdateDto, patient);
        _db.UpdatePatient(patient);

        var patientGetDto = _mapper.Map<GetPatientDto>(patient);
        return patientGetDto;
    }

    /// <summary>
    /// Retrieves a patient with the specified id.
    /// </summary>
    /// <param name="id">The identifier of the patient to retrieve.</param>
    /// <returns>The patient as a <see cref="GetPatientDto"/> if found; otherwise, null.</returns>
    public GetPatientDto? Get(int id)
    {
        var patient = _db.GetPatient(id);
        if (patient == null)
        {
            return null;
        }
        var patientGetDto = _mapper.Map<GetPatientDto>(patient);
        return patientGetDto;
    }

    /// <summary>
    /// Deletes the patient with the given id.
    /// </summary>
    /// <param name="id">The identifier of the patient to delete.</param>
    /// <returns>True if the patient was deleted; otherwise, false.</returns>
    public bool Delete(int id)
    {
        if (!_db.RemovePatient(id))
        {
            return false;
        }
        _patientId--;
        return true;
    }
}