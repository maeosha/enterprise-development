using Clinic.Models.Entities;
using Clinic.DataBase.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clinic.DataBase.EntityFramework;

/// <summary>
/// Entity Framework implementation of <see cref="IAppointmentDataBase"/> that manages
/// appointment entities using a <see cref="ClinicDbContext"/>.
/// </summary>
public sealed class EfAppointmentDataBase : IAppointmentDataBase
{
    private readonly ClinicDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="EfAppointmentDataBase"/> class.
    /// </summary>
    /// <param name="context">The database context used for data access.</param>
    public EfAppointmentDataBase(ClinicDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Retrieves an appointment by identifier.
    /// </summary>
    public Appointment? GetAppointment(int id) =>
        _context.Appointments.Find(id);

    /// <summary>
    /// Returns all appointments as a read-only collection.
    /// </summary>
    public IReadOnlyCollection<Appointment> GetAllAppointments() =>
        _context.Appointments.AsNoTracking().ToList();

    /// <summary>
    /// Returns appointments for the specified doctor.
    /// </summary>
    public IReadOnlyCollection<Appointment> GetAppointmentsByDoctor(int doctorId) =>
        _context.Appointments
            .Where(a => a.DoctorId == doctorId)
            .AsNoTracking()
            .ToList();

    /// <summary>
    /// Returns appointments for the specified patient.
    /// </summary>
    public IReadOnlyCollection<Appointment> GetAppointmentsByPatient(int patientId) =>
        _context.Appointments
            .Where(a => a.PatientId == patientId)
            .AsNoTracking()
            .ToList();

    /// <summary>
    /// Adds a new appointment. Returns <c>true</c> on success.
    /// </summary>
    public bool AddAppointment(Appointment appointment)
    {
        if (_context.Appointments.Any(a => a.Id == appointment.Id))
        {
            return false;
        }

        _context.Appointments.Add(appointment);
        _context.SaveChanges();
        return true;
    }

    /// <summary>
    /// Updates an existing appointment. Returns <c>true</c> if updated.
    /// </summary>
    public bool UpdateAppointment(Appointment appointment)
    {
        if (!_context.Appointments.Any(a => a.Id == appointment.Id))
        {
            return false;
        }

        _context.Appointments.Update(appointment);
        _context.SaveChanges();
        return true;
    }

    /// <summary>
    /// Removes an appointment by id. Returns <c>true</c> if removed.
    /// </summary>
    public bool RemoveAppointment(int id)
    {
        var entity = _context.Appointments.Find(id);
        if (entity is null)
        {
            return false;
        }

        _context.Appointments.Remove(entity);
        _context.SaveChanges();
        return true;
    }

    /// <summary>
    /// Returns total number of appointments.
    /// </summary>
    public int AppointmentCount() => _context.Appointments.Count();
}


