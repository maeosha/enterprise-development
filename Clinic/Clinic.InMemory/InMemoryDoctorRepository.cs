using Clinic.Models.Entities;

namespace Clinic.InMemory;
public sealed class InMemoryDoctorRepository
{
    /// <summary>
    /// In-memory storage for doctors.
    /// </summary>
    private readonly Dictionary<int, Doctor> _doctors = new();

    /// <summary>
    /// Retrieves a doctor by their ID.
    /// </summary>
    /// <param name="Id">The ID of the doctor to retrieve.</param>
    /// <returns>The doctor with the specified ID, or null if not found.</returns>
    public Doctor? GetDoctor(int Id) => _doctors.GetValueOrDefault(Id);

    /// <summary>
    /// Retrieves all doctors from the in-memory storage.
    /// </summary>
    /// <returns>A read-only collection of all doctors.</returns>
    public IReadOnlyCollection<Doctor> GetAllDoctors() => _doctors.Values;

    /// <summary>
    /// Adds a new doctor to the in-memory storage.
    /// </summary>
    /// <param name="doctor">The doctor to add.</param>
    /// <returns>True if the doctor was successfully added, false if it already exists.</returns>
    public bool AddDoctor(Doctor doctor){
        if (_doctors.ContainsKey(doctor.Id)){
            return false;
        }
        _doctors[doctor.Id] = doctor;
        return true;
    }

    /// <summary>
    /// Updates an existing doctor in the in-memory storage.
    /// </summary>
    /// <param name="doctor">The doctor with updated information.</param>
    /// <returns>True if the doctor was successfully updated, false if it doesn't exist.</returns>
    public bool UpdateDoctor(Doctor doctor){
        if (!_doctors.ContainsKey(doctor.Id)){
            return false;
        }
        _doctors[doctor.Id] = doctor;
        return true;
    }

    /// <summary>
    /// Removes a doctor from the in-memory storage.
    /// </summary>
    /// <param name="Id">The ID of the doctor to remove.</param>
    /// <returns>True if the doctor was successfully removed, false if it doesn't exist.</returns>
    public bool RemoveDoctor(int Id) => _doctors.Remove(Id);

    /// <summary>
    /// Gets the count of doctors in the in-memory storage.
    /// </summary>
    /// <returns>The number of doctors.</returns>
    public int DoctorCount() => _doctors.Count();
}

