using Clinic.Api.DataSeed;
using Clinic.Models.Entities;

namespace Clinic.Api.DataBase;
public sealed class ClinicDataBase : IClinicDataBase
{
    /// <summary>
    /// In-memory storage for patients, doctors, and appointments.
    /// </summary>
    private readonly Dictionary<int, Patient> _patients = new();
    private readonly Dictionary<int, Doctor> _doctors = new();
    private readonly Dictionary<int, Appointment> _appointments = new();
    private readonly Dictionary<int, Specialization> _specializations = new();

    public ClinicDataBase()
    {
        var dataSeed = new DataSeed.DataSeed();
        dataSeed.TestDataSeed(this);
    }

    public Patient? GetPatient(int Id) => _patients.GetValueOrDefault(Id);

    public IReadOnlyCollection<Patient> GetAllPatients() => _patients.Values;
    public bool AddPatient(Patient patient){
        if (_patients.ContainsValue(patient)){
            return false;
        }

        _patients[patient.Id] = patient;
        return true;
    }

    public bool UpdatePatient(Patient patient){
        if (!_patients.ContainsKey(patient.Id)){
            return false;
        }
        _patients[patient.Id] = patient;
        return true;
    }

    public bool RemovePatient(int Id) => _patients.Remove(Id);

    public int PatientCount() => _patients.Count;
    

    public IReadOnlyCollection<Specialization> GetAllSpecializations() => _specializations.Values;

    public bool AddSpecialization(Specialization specialization)
    {
        if (_specializations.ContainsValue(specialization)){
            return false;
        }
        _specializations[specialization.Id] = specialization;
        return true;
    }

    public bool RemoveSpecialization(int id) => _specializations.Remove(id);
    public Specialization? GetSpecialization(int id)
    {
        if (!_specializations.ContainsKey(id))
        {
            return null;
        }
        return _specializations[id];
    }

    public int SpecializationCount() => _specializations.Count;


    public Doctor? GetDoctor(int Id) => _doctors.GetValueOrDefault(Id);

    public IReadOnlyCollection<Doctor> GetAllDoctors() => _doctors.Values;

    public bool AddDoctor(Doctor doctor){
        if (_doctors.ContainsKey(doctor.Id)){
            return false;
        }
        _doctors[doctor.Id] = doctor;
        return true;
    }

    public bool UpdateDoctor(Doctor doctor){
        if (!_doctors.ContainsKey(doctor.Id)){
            return false;
        }
        _doctors[doctor.Id] = doctor;
        return true;
    }

    public bool RemoveDoctor(int Id) => _doctors.Remove(Id);
    
    public int DoctorCount() => _doctors.Count();

    
    public Appointment? GetAppointment(int Id) => _appointments.GetValueOrDefault(Id);

    public IReadOnlyCollection<Appointment> GetAllAppointments() => _appointments.Values;

    public IReadOnlyCollection<Appointment> GetAppointmentsByDoctor(int Id) =>
        _appointments.Values.Where(a => a.DoctorId == Id).ToList();

    public IReadOnlyCollection<Appointment> GetAppointmentsByPatient(int Id) =>
        _appointments.Values.Where(a => a.PatientId == Id).ToList();
    
    public bool AddAppointment(Appointment appointment){
        if (_appointments.ContainsKey(appointment.Id)){
            return false;
        }

        var patient = _patients.GetValueOrDefault(appointment.PatientId);
        var doctor = _doctors.GetValueOrDefault(appointment.DoctorId);

        if (patient == null || doctor == null){
            return false;
        }

        _appointments[appointment.Id] = appointment;
        return true;
    }

    public bool UpdateAppointment(Appointment appointment){
        if (!_appointments.ContainsKey(appointment.Id)){
            return false;
        }

        if (appointment.PatientId == 0 || appointment.DoctorId == 0){
            return false;
        }

        var patient = _patients.GetValueOrDefault(appointment.PatientId);

        if (patient.GetFullName() != appointment.PatientFullName){
            appointment.PatientFullName = patient.GetFullName();
        }

        var doctor = _doctors.GetValueOrDefault(appointment.DoctorId);

        if (doctor.GetFullName() != appointment.DoctorFullName){
            appointment.DoctorFullName = doctor.GetFullName();
        }

        _appointments[appointment.Id] = appointment;
        return true;
    }

    public bool RemoveAppointment(int Id) => _appointments.Remove(Id);

    public int AppointmentCount() => _appointments.Count();
}
