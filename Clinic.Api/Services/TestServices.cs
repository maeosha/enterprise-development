using AutoMapper;
using Clinic.Api.DataBase;
using Clinic.Api.DTOs.PatientDto;
using Clinic.Api.DTOs.DoctorDto;
using Clinic.Api.DTOs.Appointment;

namespace Clinic.Api.Services;

public class TestServices
{
    private readonly IClinicDataBase _db;
    private readonly IMapper _mapper;
    
    public TestServices(IClinicDataBase db, IMapper mapper){
        _db = db;
        _mapper = mapper;
    }

    /// <summary>
    /// Display information about all doctors with at least 10 years of experience.
    /// </summary>
    public IReadOnlyList<GetDoctorDto> GetDoctorsWithExperience10YearsOrMore(){
        var doctors = _db.GetAllDoctors()
            .Where(d => d.ExperienceYears >= 10)
            .ToList();
        return _mapper.Map<IReadOnlyList<GetDoctorDto>>(doctors);
    }

    /// <summary>
    /// Display information about all patients scheduled to see a specified doctor, sorted by full name.
    /// </summary>
    public IReadOnlyList<GetPatientDto>? GetPatientsByDoctorOrderedByFullName(int doctorId){
        var doctor = _db.GetDoctor(doctorId);
        if (doctor == null)
        {
            return null;
        }

        var appointments = _db.GetAppointmentsByDoctor(doctorId);
        var patients = appointments.Where(a => a.DoctorId == doctorId).Select(a => _db.GetPatient(a.PatientId)).Distinct().ToList();

        return _mapper.Map<IReadOnlyList<GetPatientDto>>(patients);
    }

    /// <summary>
    /// Display information about the number of repeat patient visits in the last month.
    /// </summary>
    public int GetReturnVisitsCountLastMonth(){
        var lastMonth = DateTime.Now.AddMonths(-1);
        var startOfLastMonth = new DateTime(lastMonth.Year, lastMonth.Month, 1);
        var startOfCurrentMonth = startOfLastMonth.AddMonths(1);

        var appointments = _db.GetAllAppointments()
            .Where(a => a.DateTime >= startOfLastMonth && 
                       a.DateTime < startOfCurrentMonth && 
                       a.IsReturnVisit)
            .Count();

        return appointments;
    }

    /// <summary>
    /// Display information about patients over 30 years old who have appointments with multiple doctors, sorted by birth date.
    /// </summary>
    public IReadOnlyList<GetPatientDto> GetPatientsOver30WithMultipleDoctorsOrderedByBirthDate(){
        var thirtyYearsAgo = DateOnly.FromDateTime(DateTime.Now.AddYears(-30));
        
        var appointments = _db.GetAllAppointments();
        
        var patientsWithMultipleDoctors = appointments
            .GroupBy(a => a.PatientId)
            .Where(g => g.Select(a => a.DoctorId).Distinct().Count() > 1)
            .Select(g => g.Key)
            .ToList();

        var patients = patientsWithMultipleDoctors
            .Select(id => _db.GetPatient(id))
            .Where(p => p != null && p.BirthDate < thirtyYearsAgo)
            .OrderBy(p => p!.BirthDate)
            .ToList();

        return _mapper.Map<IReadOnlyList<GetPatientDto>>(patients);
    }

    /// <summary>
    /// Display information about appointments for the current month that are held in the selected room.
    /// </summary>
    public IReadOnlyList<GetAppointmentDto> GetAppointmentsInRoomForCurrentMonth(int roomNumber){
        var now = DateTime.Now;
        var startOfMonth = new DateTime(now.Year, now.Month, 1);
        var startOfNextMonth = startOfMonth.AddMonths(1);

        var appointments = _db.GetAllAppointments()
            .Where(a => a.RoomNumber == roomNumber &&
                       a.DateTime >= startOfMonth &&
                       a.DateTime < startOfNextMonth)
            .OrderBy(a => a.DateTime)
            .ToList();

        return _mapper.Map<IReadOnlyList<GetAppointmentDto>>(appointments);
    }
}