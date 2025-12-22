using Clinic.Models.Entities;
using Clinic.Application.Ports;
using Microsoft.EntityFrameworkCore;

namespace Clinic.DataBase.EntityFramework;

/// <summary>
/// Entity Framework implementation of <see cref="IDoctorRepository"/> that manages
/// doctor entities via <see cref="ClinicDbContext"/>.
/// </summary>
public sealed class EfDoctorRepository : IDoctorRepository
{
    private readonly ClinicDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="EfDoctorRepository"/> class.
    /// </summary>
    /// <param name="context">The database context used for data access.</param>
    public EfDoctorRepository(ClinicDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Retrieves a doctor by identifier, including specializations.
    /// </summary>
    public Doctor? GetDoctor(int id) =>
        _context.Doctors
            .Include(d => d.Specializations)
            .FirstOrDefault(d => d.Id == id);

    /// <summary>
    /// Returns all doctors including their specializations.
    /// </summary>
    public IReadOnlyCollection<Doctor> GetAllDoctors() =>
        _context.Doctors
            .Include(d => d.Specializations)
            .AsNoTracking()
            .ToList();

    /// <summary>
    /// Adds a new doctor. Returns <c>true</c> on success.
    /// </summary>
    public bool AddDoctor(Doctor doctor)
    {
        if (_context.Doctors.Any(d => d.Id == doctor.Id))
        {
            return false;
        }

        _context.Doctors.Add(doctor);
        _context.SaveChanges();
        return true;
    }

    /// <summary>
    /// Updates an existing doctor. Returns <c>true</c> if updated.
    /// </summary>
    public bool UpdateDoctor(Doctor doctor)
    {
        if (!_context.Doctors.Any(d => d.Id == doctor.Id))
        {
            return false;
        }

        _context.Doctors.Update(doctor);
        _context.SaveChanges();
        return true;
    }

    /// <summary>
    /// Removes a doctor by id. Returns <c>true</c> if removed.
    /// </summary>
    public bool RemoveDoctor(int id)
    {
        var entity = _context.Doctors.Find(id);
        if (entity is null)
        {
            return false;
        }

        _context.Doctors.Remove(entity);
        _context.SaveChanges();
        return true;
    }

    /// <summary>
    /// Returns total count of doctors.
    /// </summary>
    public int DoctorCount() => _context.Doctors.Count();
}


