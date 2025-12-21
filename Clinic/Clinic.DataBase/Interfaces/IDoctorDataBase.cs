using Clinic.Models.Entities;

namespace Clinic.DataBase.Interfaces;

/// <summary>
/// Abstraction for doctor persistence operations.
/// Implementations should provide CRUD operations for doctor entities.
/// </summary>
public interface IDoctorDataBase
{
    /// <summary>
    /// Retrieves a doctor by identifier, or <c>null</c> if not found.
    /// </summary>
    public Doctor? GetDoctor(int id);

    /// <summary>
    /// Returns all doctors.
    /// </summary>
    public IReadOnlyCollection<Doctor> GetAllDoctors();

    /// <summary>
    /// Adds a new doctor. Returns <c>true</c> on success.
    /// </summary>
    public bool AddDoctor(Doctor doctor);

    /// <summary>
    /// Updates an existing doctor. Returns <c>true</c> if updated.
    /// </summary>
    public bool UpdateDoctor(Doctor doctor);

    /// <summary>
    /// Removes a doctor by id. Returns <c>true</c> if removed.
    /// </summary>
    public bool RemoveDoctor(int id);

    /// <summary>
    /// Returns the total count of doctors.
    /// </summary>
    public int DoctorCount();
}


