using Clinic.Models.Contracts;
using Clinic.Models.Entities;
using Clinic.Models.ReferenceBooks;
using System.Collections.Generic;

namespace Clinic.Models
{
    public class ClinicInfo
    {
        public List<Doctor> Doctors { get; set; } = new();
        public List<Patient> Patients { get; set; } = new();
        public List<Appointment> Appointments { get; set; } = new();
        public Dictionary<string, Specialisation> Specialisations { get; set; } = new();

        public ClinicInfo()
        {
            Doctors = new List<Doctor>();
            Patients = new List<Patient>();
            Appointments = new List<Appointment>();
            Specialisations = new Dictionary<string, Specialisation>();
        }

        public void AddDoctor(Doctor doctor)
        {
            Doctors.Add(doctor);
        }

        public void AddPatient(Patient patient)
        {
            Patients.Add(patient);
        }

        public void MakeAnAppointment(Appointment appointment)
        {
            Appointments.Add(appointment);
        }

        public void AddSpecialization(string key, Specialisation specialization)
        {
            Specialisations[key] = specialization;
        }
    }
}


