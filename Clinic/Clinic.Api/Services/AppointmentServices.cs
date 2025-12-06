using AutoMapper;
using Clinic.Api.DataBase;
using Clinic.Api.DTOs.Appointment;
using Clinic.Models.Entities;
using Clinic.Api.Interfaces.Services;

namespace Clinic.Api.Services;

/// <summary>
/// Service layer for managing appointments in the clinic.
/// Provides methods for creating, updating, retrieving, and deleting appointments.
/// Handles mapping between DTOs and entity models, and interacts with the appointment database.
/// </summary>
public class AppointmentServices : IAppointmentServices
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
    public IReadOnlyCollection<GetAppointmentDto> GetAll()
    {
        var appointments = _db.GetAllAppointments();
        return _mapper.Map<IReadOnlyCollection<GetAppointmentDto>>(appointments);
    }

    /// <summary>
    /// Retrieves all appointments for a specific doctor.
    /// </summary>
    /// <param name="doctorId">The identifier of the doctor.</param>
    /// <returns>A collection of appointment DTOs if the doctor exists; otherwise, null.</returns>
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

    /// <summary>
    /// Retrieves all appointments for a specific patient.
    /// </summary>
    /// <param name="patientId">The identifier of the patient.</param>
    /// <returns>A collection of appointment DTOs if the patient exists; otherwise, null.</returns>
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

    /// <summary>
    /// Retrieves a single appointment by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the appointment to retrieve.</param>
    /// <returns>The appointment as a DTO if found; otherwise, null.</returns>
    public GetAppointmentDto? Get(int id)
    {
        var appointment = _db.GetAppointment(id);
        return appointment == null ? null : _mapper.Map<GetAppointmentDto>(appointment);
    }

    /// <summary>
    /// Creates a new appointment entity in the database.
    /// </summary>
    /// <param name="dto">The DTO containing appointment creation data.</param>
    /// <returns>The created appointment as a DTO if successful; otherwise, null.</returns>
    public GetAppointmentDto? Create(CreateAppointmentDto dto)
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

    /// <summary>
    /// Updates an existing appointment with the given identifier.
    /// </summary>
    /// <param name="id">The identifier of the appointment to update.</param>
    /// <param name="dto">The DTO containing updated appointment data.</param>
    /// <returns>The updated appointment as a DTO if successful; otherwise, null.</returns>
    public GetAppointmentDto? Update(int id, UpdateAppointmentDto dto)
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

    /// <summary>
    /// Deletes an appointment from the database by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the appointment to delete.</param>
    /// <returns>True if the appointment was successfully deleted; otherwise, false.</returns>
    public bool Delete(int id)
    {
        if (!_db.RemoveAppointment(id))
        {
            return false;
        }

        _appointmentId--;
        return true;
    }
}
