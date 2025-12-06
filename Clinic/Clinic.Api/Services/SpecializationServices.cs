using AutoMapper;
using Clinic.Models.Entities;
using Clinic.Api.DataBase;
using Clinic.Api.DTOs.SpecializationDto;
using Clinic.Api.Interfaces.Services;

namespace Clinic.Api.Services;

/// <summary>
/// Service class for managing specialization-related operations in the Clinic API.
/// Provides methods to create, retrieve, and delete specializations, and maps entity objects to DTOs.
/// </summary>
public class SpecializationServices : ISpecializationServices
{
    private readonly IClinicDataBase _db;
    private readonly IMapper _mapper;
    private int _specializationId;

    /// <summary>
    /// Initializes a new instance of the <see cref="SpecializationServices"/> class.
    /// Sets the initial specialization identifier based on the count in the database.
    /// </summary>
    /// <param name="db">The database service for specialization operations.</param>
    /// <param name="mapper">The AutoMapper instance used for object mapping.</param>
    public SpecializationServices(IClinicDataBase db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
        _specializationId = _db.SpecializationCount() + 1;
    }

    /// <summary>
    /// Retrieves all specializations from the database and maps them to DTOs.
    /// </summary>
    /// <returns>A collection of <see cref="GetSpecializationDto"/> representing specializations.</returns>
    public IReadOnlyCollection<GetSpecializationDto> GetAll()
    {
        var specializations = _db.GetAllSpecializations();
        var specializationDtos = _mapper.Map<IReadOnlyCollection<GetSpecializationDto>>(specializations);
        return specializationDtos;
    }

    /// <summary>
    /// Updates an existing specialization with the given identifier.
    /// </summary>
    /// <param name="id">The identifier of the specialization to update.</param>
    /// <param name="updateSpecializationDto">The DTO containing updated specialization data.</param>
    /// <returns>The updated specialization as a DTO if successful; otherwise, null.</returns>
    public GetSpecializationDto? Update(int id, UpdateSpecializationDto updateSpecializationDto)
    {
        var specialization = _mapper.Map<Specialization>(updateSpecializationDto);
        var updatedSpecialization = _db.UpdateSpecialization(id, specialization);
        if (updatedSpecialization == null)
        {
            return null;
        }
        return _mapper.Map<GetSpecializationDto>(updatedSpecialization);
    }

    /// <summary>
    /// Creates a new specialization entity in the database.
    /// </summary>
    /// <param name="createSpecializationDto">The DTO containing specialization creation data.</param>
    /// <returns>The created specialization as a <see cref="GetSpecializationDto"/> if successful; otherwise, null.</returns>
    public GetSpecializationDto? Create(CreateSpecializationDto createSpecializationDto)
    {
        var specialization = _mapper.Map<Specialization>(createSpecializationDto);
        specialization.Id = _specializationId;

        if (!_db.AddSpecialization(specialization))
        {
            return null;
        }

        var specializationDto = _mapper.Map<GetSpecializationDto>(specialization);
        specializationDto.Id = _specializationId;

        _specializationId++;

        return specializationDto;
    }

    /// <summary>
    /// Retrieves a single specialization by ID.
    /// </summary>
    /// <param name="id">The specialization identifier.</param>
    /// <returns>A <see cref="GetSpecializationDto"/> if found; otherwise, null.</returns>
    public GetSpecializationDto? Get(int id)
    {
        var specialization = _db.GetSpecialization(id);
        if (specialization == null)
        {
            return null;
        }
        return _mapper.Map<GetSpecializationDto>(specialization);
    }

    /// <summary>
    /// Deletes a specialization by ID.
    /// </summary>
    /// <param name="id">The specialization identifier.</param>
    /// <returns>True if the specialization was deleted; otherwise, false.</returns>
    public bool Delete(int id)
    {
        return _db.RemoveSpecialization(id);
    }
}