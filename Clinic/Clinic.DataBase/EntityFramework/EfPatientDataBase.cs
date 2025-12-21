using Clinic.Models.Entities;
using Clinic.DataBase.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clinic.DataBase.EntityFramework;

/// <summary>
/// Entity Framework implementation of <see cref="IPatientDataBase"/> that manages
/// patient entities using a <see cref="ClinicDbContext"/>.
/// </summary>
public sealed class EfPatientDataBase : IPatientDataBase
{
    private readonly ClinicDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="EfPatientDataBase"/> class.
    /// </summary>
    /// <param name="context">The database context used for data access.</param>
    public EfPatientDataBase(ClinicDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Retrieves a patient by identifier.
    /// </summary>
    public Patient? GetPatient(int id) => _context.Patients.Find(id);

    /// <summary>
    /// Returns all patients from the database as a read-only collection.
    /// </summary>
    public IReadOnlyCollection<Patient> GetAllPatients() =>
        _context.Patients.AsNoTracking().ToList();

    /// <summary>
    /// Adds a new patient to the database. Returns <c>true</c> on success.
    /// </summary>
    public bool AddPatient(Patient patient)
    {
        if (_context.Patients.Any(p => p.Id == patient.Id))
        {
            return false;
        }

        _context.Patients.Add(patient);
        _context.SaveChanges();
        return true;
    }

    /// <summary>
    /// Updates an existing patient. Returns <c>true</c> if the patient existed and was updated.
    /// </summary>
    public bool UpdatePatient(Patient patient)
    {
        if (!_context.Patients.Any(p => p.Id == patient.Id))
        {
            return false;
        }

        _context.Patients.Update(patient);
        _context.SaveChanges();
        return true;
    }

    /// <summary>
    /// Removes a patient by identifier. Returns <c>true</c> if removed.
    /// </summary>
    public bool RemovePatient(int id)
    {
        var entity = _context.Patients.Find(id);
        if (entity is null)
        {
            return false;
        }

        _context.Patients.Remove(entity);
        _context.SaveChanges();
        return true;
    }

    /// <summary>
    /// Returns total number of patients in the database.
    /// </summary>
    public int PatientCount() => _context.Patients.Count();
}


