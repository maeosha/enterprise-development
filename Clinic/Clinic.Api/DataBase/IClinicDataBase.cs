using Clinic.Models.Entities;

namespace Clinic.Api.DataBase;

/// <summary>
/// Interface for a clinic database, providing CRUD operations and queries 
/// for patients, doctors, specializations, and appointments.
/// </summary>
public interface IClinicDataBase
{
    /// <summary>
    /// Retrieves a patient by their unique identifier.
    /// </summary>
    /// <param name="Id">The patient's ID.</param>
    /// <returns>The patient if found; otherwise, null.</returns>
    public Patient? GetPatient(int Id);

    /// <summary>
    /// Gets all patients in the database.
    /// </summary>
    /// <returns>A read-only collection of all patients.</returns>
    public IReadOnlyCollection<Patient> GetAllPatients();

    /// <summary>
    /// Adds a new patient to the database.
    /// </summary>
    /// <param name="patient">The patient to add.</param>
    /// <returns>True if added successfully; otherwise, false.</returns>
    public bool AddPatient(Patient patient);

    /// <summary>
    /// Updates an existing patient's details.
    /// </summary>
    /// <param name="patient">The patient with updated information.</param>
    /// <returns>True if updated successfully; otherwise, false.</returns>
    public bool UpdatePatient(Patient patient);

    /// <summary>
    /// Removes a patient by their ID.
    /// </summary>
    /// <param name="Id">The patient's ID to remove.</param>
    /// <returns>True if removed successfully; otherwise, false.</returns>
    public bool RemovePatient(int Id);

    /// <summary>
    /// Gets the total number of patients.
    /// </summary>
    /// <returns>The patient count.</returns>
    public int PatientCount();

    /// <summary>
    /// Retrieves all specializations in the system.
    /// </summary>
    /// <returns>A read-only collection of all specializations.</returns>
    public IReadOnlyCollection<Specialization> GetAllSpecializations();

    /// <summary>
    /// Adds a new specialization.
    /// </summary>
    /// <param name="specialization">The specialization to add.</param>
    /// <returns>True if added; false if already exists.</returns>
    public bool AddSpecialization(Specialization specialization);

    /// <summary>
    /// Updates an existing specialization.
    /// </summary>
    /// <param name="specialization">The specialization with updated information.</param>
    /// <returns>True if updated; otherwise, false.</returns>
    public Specialization? UpdateSpecialization(int id, Specialization specialization);

    /// <summary>
    /// Retrieves a specialization by its unique identifier.
    /// </summary>
    /// <param name="id">The specialization's ID.</param>
    /// <returns>The specialization if found; otherwise, null.</returns>
    public Specialization? GetSpecialization(int id);

    /// <summary>
    /// Removes a specialization by its ID.
    /// </summary>
    /// <param name="id">The specialization's ID.</param>
    /// <returns>True if removed; otherwise, false.</returns>
    public bool RemoveSpecialization(int id);

    /// <summary>
    /// Gets the total specialization count.
    /// </summary>
    /// <returns>The number of specializations.</returns>
    public int SpecializationCount();

    /// <summary>
    /// Retrieves a doctor by their unique identifier.
    /// </summary>
    /// <param name="Id">The doctor's ID.</param>
    /// <returns>The doctor if found; otherwise, null.</returns>
    public Doctor? GetDoctor(int Id);

    /// <summary>
    /// Gets all doctors.
    /// </summary>
    /// <returns>A read-only collection of all doctors.</returns>
    public IReadOnlyCollection<Doctor> GetAllDoctors();

    /// <summary>
    /// Adds a new doctor.
    /// </summary>
    /// <param name="doctor">The doctor to add.</param>
    /// <returns>True if added; otherwise, false.</returns>
    public bool AddDoctor(Doctor doctor);

    /// <summary>
    /// Updates details for an existing doctor.
    /// </summary>
    /// <param name="doctor">The doctor with updated details.</param>
    /// <returns>True if updated; otherwise, false.</returns>
    public bool UpdateDoctor(Doctor doctor);

    /// <summary>
    /// Removes a doctor by their ID.
    /// </summary>
    /// <param name="Id">The doctor's ID.</param>
    /// <returns>True if removed; otherwise, false.</returns>
    public bool RemoveDoctor(int Id);

    /// <summary>
    /// Gets the total doctor count.
    /// </summary>
    /// <returns>The number of doctors.</returns>
    public int DoctorCount();

    /// <summary>
    /// Retrieves an appointment by its unique identifier.
    /// </summary>
    /// <param name="Id">The appointment's ID.</param>
    /// <returns>The appointment if found; otherwise, null.</returns>
    public Appointment? GetAppointment(int Id);

    /// <summary>
    /// Gets all appointments.
    /// </summary>
    /// <returns>A read-only collection of all appointments.</returns>
    public IReadOnlyCollection<Appointment> GetAllAppointments();

    /// <summary>
    /// Gets all appointments for a specific doctor.
    /// </summary>
    /// <param name="Id">The doctor's ID.</param>
    /// <returns>A collection of appointments for the doctor.</returns>
    public IReadOnlyCollection<Appointment> GetAppointmentsByDoctor(int Id);

    /// <summary>
    /// Gets all appointments for a specific patient.
    /// </summary>
    /// <param name="Id">The patient's ID.</param>
    /// <returns>A collection of appointments for the patient.</returns>
    public IReadOnlyCollection<Appointment> GetAppointmentsByPatient(int Id);

    /// <summary>
    /// Adds a new appointment.
    /// </summary>
    /// <param name="appointment">The appointment to add.</param>
    /// <returns>True if added; otherwise, false.</returns>
    public bool AddAppointment(Appointment appointment);

    /// <summary>
    /// Updates an existing appointment.
    /// </summary>
    /// <param name="appointment">The appointment with updated details.</param>
    /// <returns>True if updated; otherwise, false.</returns>
    public bool UpdateAppointment(Appointment appointment);

    /// <summary>
    /// Removes an appointment by its ID.
    /// </summary>
    /// <param name="Id">The appointment's ID.</param>
    /// <returns>True if removed; otherwise, false.</returns>
    public bool RemoveAppointment(int Id);

    /// <summary>
    /// Gets the total appointment count.
    /// </summary>
    /// <returns>The number of appointments.</returns>
    public int AppointmentCount();
}