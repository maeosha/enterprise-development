using Clinic.Models.Entities;

namespace Clinic.Application.Ports;

/// <summary>
/// Abstraction for specialization persistence operations.
/// Provides methods to query and modify specializations.
/// </summary>
public interface ISpecializationRepository
{
    /// <summary>
    /// Returns all specializations.
    /// </summary>
    public IReadOnlyCollection<Specialization> GetAllSpecializations();

    /// <summary>
    /// Adds a new specialization. Returns <c>true</c> on success.
    /// </summary>
    public bool AddSpecialization(Specialization specialization);

    /// <summary>
    /// Updates an existing specialization and returns the updated entity, or <c>null</c> if not found.
    /// </summary>
    public Specialization? UpdateSpecialization(int id, Specialization specialization);

    /// <summary>
    /// Retrieves a specialization by identifier.
    /// </summary>
    public Specialization? GetSpecialization(int id);

    /// <summary>
    /// Removes a specialization by id. Returns <c>true</c> if removed.
    /// </summary>
    public bool RemoveSpecialization(int id);

    /// <summary>
    /// Returns total number of specializations.
    /// </summary>
    public int SpecializationCount();
}


