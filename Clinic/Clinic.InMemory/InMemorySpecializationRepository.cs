using Clinic.Application.Ports;
using Clinic.Models.Entities;

namespace Clinic.InMemory;
public sealed class InMemorySpecializationRepository : ISpecializationRepository
{
    /// <summary>
    /// In-memory storage for specializations.
    /// </summary>
    private readonly Dictionary<int, Specialization> _specializations = new();

    /// <summary>
    /// Retrieves all specializations from the in-memory storage.
    /// </summary>
    /// <returns>A read-only collection of all specializations.</returns>
    public IReadOnlyCollection<Specialization> GetAllSpecializations() => _specializations.Values;

    /// <summary>
    /// Adds a new specialization to the in-memory storage.
    /// </summary>
    /// <param name="specialization">The specialization to add.</param>
    /// <returns>True if the specialization was successfully added, false if it already exists.</returns>
    public bool AddSpecialization(Specialization specialization)
    {
        if (_specializations.ContainsKey(specialization.Id)){
            return false;
        }
        _specializations[specialization.Id] = specialization;
        return true;
    }

    /// <summary>
    /// Removes a specialization from the in-memory storage.
    /// </summary>
    /// <param name="id">The ID of the specialization to remove.</param>
    /// <returns>True if the specialization was successfully removed, false if it doesn't exist.</returns>
    public bool RemoveSpecialization(int id) => _specializations.Remove(id);

    /// <summary>
    /// Retrieves a specialization by its ID.
    /// </summary>
    /// <param name="id">The ID of the specialization to retrieve.</param>
    /// <returns>The specialization with the specified ID, or null if not found.</returns>
    public Specialization? GetSpecialization(int id)
    {
        if (!_specializations.ContainsKey(id))
        {
            return null;
        }
        return _specializations[id];
    }

    /// <summary>
    /// Gets the count of specializations in the in-memory storage.
    /// </summary>
    /// <returns>The number of specializations.</returns>
    public int SpecializationCount() => _specializations.Count;

    /// <summary>
    /// Updates an existing specialization in the in-memory storage.
    /// </summary>
    /// <param name="id">The ID of the specialization to update.</param>
    /// <param name="specialization">The specialization with updated information.</param>
    /// <returns>The updated specialization, or null if it doesn't exist.</returns>
    public Specialization? UpdateSpecialization(int id, Specialization specialization){
        if (!_specializations.ContainsKey(id)){
            return null;
        }
        _specializations[id].Name = specialization.Name;
        return _specializations[id];
    }
}
