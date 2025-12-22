using AutoMapper;
using Clinic.Application.Ports;
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
    private readonly IAppointmentRepository _appointments;
    private readonly IPatientRepository _patients;
    private readonly IDoctorRepository _doctors;
    private readonly IMapper _mapper;
    private int _appointmentId;

    /// <summary>
    /// Initializes a new instance of the <see cref="AppointmentServices"/> class.
    /// </summary>
    /// <param name="appointments">The appointment database interface.</param>
    /// <param name="patients">The patient database interface.</param>
    /// <param name="doctors">The doctor database interface.</param>
    /// <param name="mapper">The AutoMapper interface for DTO and entity mapping.</param>
    public AppointmentServices(
        IAppointmentRepository appointments,
        IPatientRepository patients,
        IDoctorRepository doctors,
        IMapper mapper)
    {
        _appointments = appointments;
        _patients = patients;
        _doctors = doctors;
        _mapper = mapper;
        _appointmentId = _appointments.AppointmentCount() + 1;
    }

    /// <summary>
    /// Retrieves all appointments from the database.
    /// </summary>
    /// <returns>A read-only collection of appointment DTOs.</returns>
    public IReadOnlyCollection<GetAppointmentDto> GetAll()
    {
        var appointments = _appointments.GetAllAppointments();
        return _mapper.Map<IReadOnlyCollection<GetAppointmentDto>>(appointments);
    }

    /// <summary>
    /// Retrieves all appointments for a specific doctor.
    /// </summary>
    /// <param name="doctorId">The identifier of the doctor.</param>
    /// <returns>A collection of appointment DTOs if the doctor exists; otherwise, null.</returns>
    public IReadOnlyCollection<GetAppointmentDto>? GetAppointmentsByDoctor(int doctorId)
    {
        var doctor = _doctors.GetDoctor(doctorId);
        if (doctor == null)
        {
            return null;
        }
        var appointments = _appointments.GetAppointmentsByDoctor(doctorId);
        return _mapper.Map<IReadOnlyCollection<GetAppointmentDto>>(appointments);
    }

    /// <summary>
    /// Retrieves all appointments for a specific patient.
    /// </summary>
    /// <param name="patientId">The identifier of the patient.</param>
    /// <returns>A collection of appointment DTOs if the patient exists; otherwise, null.</returns>
    public IReadOnlyCollection<GetAppointmentDto>? GetAppointmentsByPatient(int patientId)
    {
        var patient = _patients.GetPatient(patientId);
        if (patient == null)
        {
            return null;
        }
        var appointments = _appointments.GetAppointmentsByPatient(patientId);
        return _mapper.Map<IReadOnlyCollection<GetAppointmentDto>>(appointments);
    }

    /// <summary>
    /// Retrieves a single appointment by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the appointment to retrieve.</param>
    /// <returns>The appointment as a DTO if found; otherwise, null.</returns>
    public GetAppointmentDto? Get(int id)
    {
        var appointment = _appointments.GetAppointment(id);
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

        if (!_appointments.AddAppointment(appointment))
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
        var appointment = _appointments.GetAppointment(id);
        if (appointment == null)
        {
            return null;
        }

        _mapper.Map(dto, appointment);
        _appointments.UpdateAppointment(appointment);

        return _mapper.Map<GetAppointmentDto>(appointment);
    }

    /// <summary>
    /// Deletes an appointment from the database by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the appointment to delete.</param>
    /// <returns>True if the appointment was successfully deleted; otherwise, false.</returns>
    public bool Delete(int id)
    {
        if (!_appointments.RemoveAppointment(id))
        {
            return false;
        }

        _appointmentId--;
        return true;
    }
}
