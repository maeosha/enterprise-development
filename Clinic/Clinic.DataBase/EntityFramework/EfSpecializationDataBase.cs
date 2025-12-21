using Clinic.Models.Entities;
using Clinic.DataBase.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clinic.DataBase.EntityFramework;

/// <summary>
/// Entity Framework implementation of <see cref="ISpecializationDataBase"/> that manages
/// specialization entities using <see cref="ClinicDbContext"/>.
/// </summary>
public sealed class EfSpecializationDataBase : ISpecializationDataBase
{
    private readonly ClinicDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="EfSpecializationDataBase"/> class.
    /// </summary>
    /// <param name="context">The database context used for data access.</param>
    public EfSpecializationDataBase(ClinicDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Returns all specializations as a read-only collection.
    /// </summary>
    public IReadOnlyCollection<Specialization> GetAllSpecializations() =>
        _context.Specializations.AsNoTracking().ToList();

    /// <summary>
    /// Adds a new specialization. Returns <c>true</c> on success.
    /// </summary>
    public bool AddSpecialization(Specialization specialization)
    {
        if (_context.Specializations.Any(s => s.Id == specialization.Id))
        {
            return false;
        }

        _context.Specializations.Add(specialization);
        _context.SaveChanges();
        return true;
    }

    /// <summary>
    /// Updates a specialization by id and returns the updated entity, or <c>null</c> if not found.
    /// </summary>
    public Specialization? UpdateSpecialization(int id, Specialization specialization)
    {
        var existing = _context.Specializations.Find(id);
        if (existing is null)
        {
            return null;
        }

        existing.Name = specialization.Name;
        _context.SaveChanges();
        return existing;
    }


    /// <summary>
    /// Retrieves a specialization by identifier.
    /// </summary>
    public Specialization? GetSpecialization(int id) =>
        _context.Specializations.Find(id);

    /// <summary>
    /// Removes a specialization by id. Returns <c>true</c> if removed.
    /// </summary>
    public bool RemoveSpecialization(int id)
    {
        var entity = _context.Specializations.Find(id);
        if (entity is null)
        {
            return false;
        }

        _context.Specializations.Remove(entity);
        _context.SaveChanges();
        return true;
    }

    /// <summary>
    /// Returns total number of specializations.
    /// </summary>
    public int SpecializationCount() => _context.Specializations.Count();
}


