using System;
using Clinic.Models;
using Clinic.Models.Entities;
using Microsoft.VisualBasic;

namespace Clinic.Tests
{
    public class ClinicTests
    {
        public readonly ClinicInfo clinic = new ClinicDataSeed().clinic;

        [Fact]
        public void GetDoctors_ReturnsDoctorsWith10OrMoreYearsOfExperience()
        {
            List<String> DoctorsWith10OrMoreYearsOfExperience = new List<String>{
                "Смирнов Андрей Иванович",
                "Петров Сергей Викторович",
                "Орлова Елена Александровна",
                "Лебедев Алексей Игоревич",
                "Соколова Ирина Михайловна",
                "Григорьева Наталья Валерьевна"
            };

            var res_doctors = clinic.Doctors.Where(d => d.ExperienceYears >= 10).ToList();
            var resDoctorsWith10OrMoreYearsOfExperience = new List<String>();

            foreach (var doctor in res_doctors)
            {
                resDoctorsWith10OrMoreYearsOfExperience.Add(doctor.GetFullName());
            }

            Assert.Equal(DoctorsWith10OrMoreYearsOfExperience, resDoctorsWith10OrMoreYearsOfExperience);
        }

        [Fact]
        public void GetTargerDoctor_ReturnsPatientsWhoHaveAppointmentWithTargetDoctor()
        {
            Doctor targetDoctor = clinic.Doctors.First(d => d.LastName == "Смирнов" && d.FirstName == "Андрей");
            List<String> patientsWhoHaveAppointmentWithTargetDocor = [
                "Иванов Иван Иванович",
                "Сидоров Алексей Петрович"
            ];

            var res_patients = clinic.Appointments
                .Where(d => d.Doctor == targetDoctor)
                .Select(p => p.Patient)
                .Distinct()
                .OrderBy(n => n.LastName)
                .ThenBy(n => n.FirstName)
                .ThenBy(n => n.Patronymic)
                .ToList();

            var result = new List<String>();

            foreach (var patient in res_patients)
            {
                result.Add(patient.GetFullName());
            }

            Assert.Equal(patientsWhoHaveAppointmentWithTargetDocor, result);
        }

        [Fact]
        public void GetAppointmentInTheLastMonths_ReturnsRepeatedAppointment()
        {
            var CountRepeatedAppointments = 6;

            DateTime now = DateTime.Now;
            DateTime lastMonth = now.AddMonths(-1);

            var resCountRepeatedAppointments = clinic.Appointments
                .Where(a => a.DateTime >= lastMonth && a.IsReturnVisit)
                .Count();

            Assert.Equal(CountRepeatedAppointments, resCountRepeatedAppointments);
        }

        [Fact]
        public void GetPationsOver30_ReturnsPationsWhoHaveAppointmentWithSeveralDoctors()
        {
            var PationsWhoHaveAppointmentWithSeveralDoctors = new List<String>
            {
                "Морозов Сергей Викторович",
                "Сидоров Алексей Петрович",
                "Петрова Мария Сергеевна"
            };

            var currentDate = DateTime.Now;
            var age30 = currentDate.AddYears(-30);

            var patients = clinic.Patients
                .Where(a => a.BirthDate <= age30)
                .Where(p => clinic.Appointments.Count(a => a.Patient.PassportNumber == p.PassportNumber) > 1)
                .OrderBy(d => d.BirthDate)
                .ToList();

            var resPationsWhoHaveAppointmentWithSeveralDoctors = new List<String>();
            foreach (var patient in patients)
            {
                resPationsWhoHaveAppointmentWithSeveralDoctors.Add(patient.GetFullName());
            }
            Assert.Equal(PationsWhoHaveAppointmentWithSeveralDoctors, resPationsWhoHaveAppointmentWithSeveralDoctors);
        }
        [Fact]
        public void GetTargetRoom_ReturnsCountAppointmentsInTheLastMonthThatTookPlaceInTargetRoom()
        {
            var CountAppointmentsInTheLastMonthThatTookPlaceInTargetRoom = 3;

            var targetRoom = 303;
            DateTime now = DateTime.Now;
            DateTime lastMonth = now.AddMonths(-1);


            int resCountAppointmentsInTheLastMonthThatTookPlaceInTargetRoom = clinic.Appointments
                .Where(a => a.RoomNumber == targetRoom &&
                       a.DateTime >= lastMonth)
                .Count();

            Assert.Equal(CountAppointmentsInTheLastMonthThatTookPlaceInTargetRoom, resCountAppointmentsInTheLastMonthThatTookPlaceInTargetRoom);
        }
    }
}
