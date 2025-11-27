using AutoMapper;
using Clinic.Api.DataBase;
using Clinic.Api.DTOs.Appointment;
using Clinic.Models.Entities;

namespace Clinic.Api.Services;

/// <summary>
/// Service layer for managing appointments in the clinic.
/// Provides methods for creating, updating, retrieving, and deleting appointments.
/// Handles mapping between DTOs and entity models, and interacts with the appointment database.
/// </summary>
public class AppointmentServices
{
    private readonly IClinicDataBase _db;
    private readonly IMapper _mapper;
    private int _appointmentId;

    /// <summary>
    /// Initializes a new instance of the <see cref="AppointmentServices"/> class.
    /// </summary>
    /// <param name="db">The clinic database interface.</param>
    /// <param name="mapper">The AutoMapper interface for DTO and entity mapping.</param>
    public AppointmentServices(IClinicDataBase db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
        _appointmentId = _db.AppointmentCount() + 1;
    }

    /// <summary>
    /// Retrieves all appointments from the database.
    /// </summary>
    /// <returns>A read-only collection of appointment DTOs.</returns>
    public IReadOnlyCollection<GetAppointmentDto> GetAllAppointments()
    {
        var appointments = _db.GetAllAppointments();
        return _mapper.Map<IReadOnlyCollection<GetAppointmentDto>>(appointments);
    }

    public IReadOnlyCollection<GetAppointmentDto>? GetAppointmentsByDoctor(int doctorId)
    {
        var doctor = _db.GetDoctor(doctorId);
        if (doctor == null)
        {
            return null;
        }
        var appointments = _db.GetAppointmentsByDoctor(doctorId);
        return _mapper.Map<IReadOnlyCollection<GetAppointmentDto>>(appointments);
    }

    public IReadOnlyCollection<GetAppointmentDto>? GetAppointmentsByPatient(int patientId)
    {
        var patient = _db.GetPatient(patientId);
        if (patient == null)
        {
            return null;
        }
        var appointments = _db.GetAppointmentsByPatient(patientId);
        return _mapper.Map<IReadOnlyCollection<GetAppointmentDto>>(appointments);
    }

    public GetAppointmentDto? GetAppointment(int id)
    {
        var appointment = _db.GetAppointment(id);
        return appointment == null ? null : _mapper.Map<GetAppointmentDto>(appointment);
    }

    public GetAppointmentDto? CreateAppointment(CreateAppointmentDto dto)
    {
        var appointment = _mapper.Map<Appointment>(dto);
        appointment.Id = _appointmentId;

        if (!_db.AddAppointment(appointment))
        {
            return null;
        }

        _appointmentId++;
        return _mapper.Map<GetAppointmentDto>(appointment);
    }

    public GetAppointmentDto? UpdateAppointment(int id, UpdateAppointmentDto dto)
    {
        var appointment = _db.GetAppointment(id);
        if (appointment == null)
        {
            return null;
        }

        _mapper.Map(dto, appointment);
        _db.UpdateAppointment(appointment);

        return _mapper.Map<GetAppointmentDto>(appointment);
    }

    public bool DeleteAppointment(int id)
    {
        if (!_db.RemoveAppointment(id))
        {
            return false;
        }

        _appointmentId--;
        return true;
    }
}
