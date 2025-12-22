using Clinic.Models.Entities;

namespace Clinic.Application.Ports;

/// <summary>
/// Abstraction for patient persistence operations.
/// Implementations should provide methods to get, add, update and remove patients.
/// </summary>
public interface IPatientRepository
{
    /// <summary>
    /// Retrieves a patient by identifier.
    /// </summary>
    public Patient? GetPatient(int id);

    /// <summary>
    /// Returns all patients.
    /// </summary>
    public IReadOnlyCollection<Patient> GetAllPatients();

    /// <summary>
    /// Adds a new patient. Returns <c>true</c> on success.
    /// </summary>
    public bool AddPatient(Patient patient);

    /// <summary>
    /// Updates an existing patient. Returns <c>true</c> if updated.
    /// </summary>
    public bool UpdatePatient(Patient patient);

    /// <summary>
    /// Removes a patient by id. Returns <c>true</c> if removed.
    /// </summary>
    public bool RemovePatient(int id);

    /// <summary>
    /// Returns the total count of patients.
    /// </summary>
    public int PatientCount();
}


