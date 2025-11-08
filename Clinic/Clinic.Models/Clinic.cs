using Clinic.Models.Entities;
using Clinic.Models.ReferenceBooks;
using System.Collections.Generic;

namespace Clinic.Models;

/// <summary>
/// Central in-memory storage for clinic data.
/// </summary>
public class ClinicInfo
{
    /// <summary>
    /// Gets or sets the list of doctors.
    /// </summary>
    public List<Doctor> Doctors { get; set; } = new();

    /// <summary>
    /// Gets or sets the list of patients.
    /// </summary>
    public List<Patient> Patients { get; set; } = new();

    /// <summary>
    /// Gets or sets the list of appointments.
    /// </summary>
    public List<Appointment> Appointments { get; set; } = new();

    /// <summary>
    /// Gets or sets the dictionary of specializations.
    /// </summary>
    public Dictionary<string, Specialization> Specializations { get; set; } = new();

    /// <summary>
    /// Adds a doctor to the clinic.
    /// </summary>
    /// <param name="doctor">The doctor to add.</param>
    public void AddDoctor(Doctor doctor)
    {
        Doctors.Add(doctor);
    }

    /// <summary>
    /// Adds a patient to the clinic.
    /// </summary>
    /// <param name="patient">The patient to add.</param>
    public void AddPatient(Patient patient)
    {
        Patients.Add(patient);
    }

    /// <summary>
    /// Schedules an appointment.
    /// </summary>
    /// <param name="appointment">The appointment to schedule.</param>
    public void MakeAnAppointment(Appointment appointment)
    {
        Appointments.Add(appointment);
    }

    /// <summary>
    /// Adds or updates a specialization.
    /// </summary>
    /// <param name="key">The specialization code.</param>
    /// <param name="specialization">The specialization object.</param>
    public void AddSpecialization(string key, Specialization specialization)
    {
        Specializations[key] = specialization;
    }
}