using AutoMapper;
using Clinic.DataBase.Interfaces;
using Clinic.Api.DTOs.Doctor;
using Clinic.Models.Entities;
using Clinic.Api.Interfaces.Services;

namespace Clinic.Api.Services;

/// <summary>
/// Service class for managing doctor-related operations within the Clinic API.
/// Provides methods to create, retrieve, update, and delete doctors,
/// as well as functions to get all doctors from the underlying database.
/// Uses AutoMapper for mapping between entity and DTO objects.
/// </summary>
public class DoctorServices : IDoctorServices
{
    private readonly IDoctorDataBase _db;
    private readonly IMapper _mapper;
    private int _doctorId;

    /// <summary>
    /// Initializes a new instance of the <see cref="DoctorServices"/> class.
    /// Sets the initial doctor identifier based on the count in the database.
    /// </summary>
    /// <param name="db">The database service for doctor operations.</param>
    /// <param name="mapper">The AutoMapper instance used for object mapping.</param>
    public DoctorServices(IDoctorDataBase db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
        _doctorId = _db.DoctorCount() + 1;
    }

    /// <summary>
    /// Retrieves all doctors from the database and maps them to DTOs.
    /// </summary>
    /// <returns>A collection of <see cref="GetDoctorDto"/> representing doctors.</returns>
    public IReadOnlyCollection<GetDoctorDto> GetAll()
    {
        var doctors = _db.GetAllDoctors();
        var doctorsDto = _mapper.Map<IReadOnlyCollection<GetDoctorDto>>(doctors);
        return doctorsDto;
    }

    /// <summary>
    /// Creates a new doctor entity in the database.
    /// </summary>
    /// <param name="createDoctorDto">The DTO containing doctor creation data.</param>
    /// <returns>The created doctor as a <see cref="GetDoctorDto"/> if successful; otherwise, null.</returns>
    public GetDoctorDto? Create(CreateDoctorDto createDoctorDto)
    {
        var doctor = _mapper.Map<Doctor>(createDoctorDto);
        doctor.Id = _doctorId;
        if (!_db.AddDoctor(doctor))
        {
            return null;
        }
        return _mapper.Map<GetDoctorDto>(doctor);
    }

    /// <summary>
    /// Retrieves a single doctor by ID.
    /// </summary>
    /// <param name="id">The doctor identifier.</param>
    /// <returns>A <see cref="GetDoctorDto"/> if found; otherwise, null.</returns>
    public GetDoctorDto? Get(int id)
    {
        var doctor = _db.GetDoctor(id);
        if (doctor == null)
        {
            return null;
        }
        var doctorGetDto = _mapper.Map<GetDoctorDto>(doctor);
        return doctorGetDto;
    }

    /// <summary>
    /// Updates an existing doctor's information.
    /// </summary>
    /// <param name="id">The doctor identifier.</param>
    /// <param name="updateDoctorDto">DTO with updated doctor details.</param>
    /// <returns>The updated doctor as a <see cref="GetDoctorDto"/> if successful; otherwise, null.</returns>
    public GetDoctorDto? Update(int id, UpdateDoctorDto updateDoctorDto)
    {
        var doctor = _db.GetDoctor(id);
        if (doctor == null)
        {
            return null;
        }
        _mapper.Map(updateDoctorDto, doctor);
        _db.UpdateDoctor(doctor);

        var doctorGetDto = _mapper.Map<GetDoctorDto>(doctor);
        return doctorGetDto;
    }

    /// <summary>
    /// Deletes a doctor from the database by ID.
    /// </summary>
    /// <param name="id">The doctor identifier to delete.</param>
    /// <returns>True if the doctor was successfully deleted; otherwise, false.</returns>
    public bool Delete(int id)
    {
        if (!_db.RemoveDoctor(id))
        {
            return false;
        }
        _doctorId--;
        return true;
    }
}