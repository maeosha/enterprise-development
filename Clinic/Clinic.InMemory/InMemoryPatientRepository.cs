using Clinic.Models.Entities;

namespace Clinic.InMemory;
public sealed class InMemoryPatientRepository
{
    /// <summary>
    /// In-memory storage for patients.
    /// </summary>
    private readonly Dictionary<int, Patient> _patients = new();

    /// <summary>
    /// Retrieves all patients from the in-memory storage.
    /// </summary>
    /// <returns>A read-only collection of all patients.</returns>
    public IReadOnlyCollection<Patient> GetAllPatients() => _patients.Values;

    /// <summary>
    /// Adds a new patient to the in-memory storage.
    /// </summary>
    /// <param name="patient">The patient to add.</param>
    /// <returns>True if the patient was successfully added, false if it already exists.</returns>
    public bool AddPatient(Patient patient){
        if (_patients.ContainsKey(patient.Id)){
            return false;
        }

        _patients[patient.Id] = patient;
        return true;
    }

    /// <summary>
    /// Updates an existing patient in the in-memory storage.
    /// </summary>
    /// <param name="patient">The patient with updated information.</param>
    /// <returns>True if the patient was successfully updated, false if it doesn't exist.</returns>
    public bool UpdatePatient(Patient patient){
        if (!_patients.ContainsKey(patient.Id)){
            return false;
        }
        _patients[patient.Id] = patient;
        return true;
    }

    /// <summary>
    /// Removes a patient from the in-memory storage.
    /// </summary>
    /// <param name="Id">The ID of the patient to remove.</param>
    /// <returns>True if the patient was successfully removed, false if it doesn't exist.</returns>
    public bool RemovePatient(int Id) => _patients.Remove(Id);

    /// <summary>
    /// Gets the count of patients in the in-memory storage.
    /// </summary>
    /// <returns>The number of patients.</returns>
    public int PatientCount() => _patients.Count;
}