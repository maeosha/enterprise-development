using Clinic.Models;
using Clinic.Models.Entities;
using Clinic.Models.Enums;
using Clinic.Models.ReferenceBooks;
using Clinic.Models.Contracts;
using Microsoft.VisualBasic;
using System;

namespace Clinic.Tests
{
    public class ClinicDataSeed
    {
        public ClinicInfo clinic{ get; set; } = new ClinicInfo();
        public ClinicDataSeed()
        {
            var patient1 = new Patient
            {
                PassportNumber = "P001",
                LastName = "Иванов",
                FirstName = "Иван",
                Patronymic = "Иванович",
                Gender = Gender.Male,
                BirthDate = new DateTime(1985, 5, 20),
                Address = "г. Москва, ул. Ленина, д. 10",
                BloodGroup = BloodGroup.Second,
                RhesusFactor = RhesusFactor.Positive,
                PhoneNumber = "+79991234567"
            };
            clinic.AddPatient(patient1);

            var patient2 = new Patient
            {
                PassportNumber = "P002",
                LastName = "Петрова",
                FirstName = "Мария",
                Patronymic = "Сергеевна",
                Gender = Gender.Female,
                BirthDate = new DateTime(1990, 8, 15),
                Address = "г. Санкт-Петербург, ул. Пушкина, д. 25",
                BloodGroup = BloodGroup.First,
                RhesusFactor = RhesusFactor.Positive,
                PhoneNumber = "+79992345678"
            };
            clinic.AddPatient(patient2);

            var patient3 = new Patient
            {
                PassportNumber = "P003",
                LastName = "Сидоров",
                FirstName = "Алексей",
                Patronymic = "Петрович",
                Gender = Gender.Male,
                BirthDate = new DateTime(1978, 12, 3),
                Address = "г. Екатеринбург, ул. Мира, д. 15",
                BloodGroup = BloodGroup.Third,
                RhesusFactor = RhesusFactor.Negative,
                PhoneNumber = "+79993456789"
            };
            clinic.AddPatient(patient3);

            var patient4 = new Patient
            {
                PassportNumber = "P004",
                LastName = "Кузнецова",
                FirstName = "Ольга",
                Patronymic = "Владимировна",
                Gender = Gender.Female,
                BirthDate = new DateTime(1995, 3, 10),
                Address = "г. Новосибирск, ул. Советская, д. 8",
                BloodGroup = BloodGroup.Fourth,
                RhesusFactor = RhesusFactor.Positive,
                PhoneNumber = "+79994567890"
            };
            clinic.AddPatient(patient4);

            var patient5 = new Patient
            {
                PassportNumber = "P005",
                LastName = "Васильев",
                FirstName = "Дмитрий",
                Patronymic = "Александрович",
                Gender = Gender.Male,
                BirthDate = new DateTime(1982, 7, 28),
                Address = "г. Казань, ул. Гагарина, д. 12",
                BloodGroup = BloodGroup.Second,
                RhesusFactor = RhesusFactor.Negative,
                PhoneNumber = "+79995678901"
            };
            clinic.AddPatient(patient5);

            var patient6 = new Patient
            {
                PassportNumber = "P006",
                LastName = "Николаева",
                FirstName = "Елена",
                Patronymic = "Игоревна",
                Gender = Gender.Female,
                BirthDate = new DateTime(1988, 11, 5),
                Address = "г. Нижний Новгород, ул. Лермонтова, д. 30",
                BloodGroup = BloodGroup.First,
                RhesusFactor = RhesusFactor.Negative,
                PhoneNumber = "+79996789012"
            };
            clinic.AddPatient(patient6);

            var patient7 = new Patient
            {
                PassportNumber = "P007",
                LastName = "Морозов",
                FirstName = "Сергей",
                Patronymic = "Викторович",
                Gender = Gender.Male,
                BirthDate = new DateTime(1975, 1, 18),
                Address = "г. Самара, ул. Чехова, д. 7",
                BloodGroup = BloodGroup.Third,
                RhesusFactor = RhesusFactor.Positive,
                PhoneNumber = "+79997890123"
            };
            clinic.AddPatient(patient7);

            var patient8 = new Patient
            {
                PassportNumber = "P008",
                LastName = "Орлова",
                FirstName = "Анна",
                Patronymic = "Дмитриевна",
                Gender = Gender.Female,
                BirthDate = new DateTime(1992, 9, 22),
                Address = "г. Ростов-на-Дону, ул. Кирова, д. 18",
                BloodGroup = BloodGroup.Fourth,
                RhesusFactor = RhesusFactor.Negative,
                PhoneNumber = "+79998901234"
            };
            clinic.AddPatient(patient8);

            var patient9 = new Patient
            {
                PassportNumber = "P009",
                LastName = "Павлов",
                FirstName = "Михаил",
                Patronymic = "Олегович",
                Gender = Gender.Male,
                BirthDate = new DateTime(1980, 4, 14),
                Address = "г. Уфа, ул. Горького, д. 22",
                BloodGroup = BloodGroup.First,
                RhesusFactor = RhesusFactor.Positive,
                PhoneNumber = "+79999012345"
            };
            clinic.AddPatient(patient9);

            var patient10 = new Patient
            {
                PassportNumber = "P010",
                LastName = "Федорова",
                FirstName = "Татьяна",
                Patronymic = "Николаевна",
                Gender = Gender.Female,
                BirthDate = new DateTime(1987, 6, 30),
                Address = "г. Красноярск, ул. Ленина, д. 5",
                BloodGroup = BloodGroup.Second,
                RhesusFactor = RhesusFactor.Positive,
                PhoneNumber = "+79990123456"
            };
            clinic.AddPatient(patient10);

            clinic.AddSpecialization("Therapist", new Specialisation { Id = 1, Name = "Терапевт" });
            clinic.AddSpecialization("Dentist", new Specialisation { Id = 2, Name = "Стоматолог" });
            clinic.AddSpecialization("Cardiologist", new Specialisation { Id = 3, Name = "Кардиолог" });
            clinic.AddSpecialization("Neurologist", new Specialisation { Id = 4, Name = "Невролог" });
            clinic.AddSpecialization("Pediatrician", new Specialisation { Id = 5, Name = "Педиатр" });
            clinic.AddSpecialization("Dermatologist", new Specialisation { Id = 6, Name = "Дерматолог" });
            clinic.AddSpecialization("Psychiatrist", new Specialisation { Id = 7, Name = "Психиатр" });
            clinic.AddSpecialization("Ophthalmologist", new Specialisation { Id = 8, Name = "Офтальмолог" });
            clinic.AddSpecialization("ENTSpecialist", new Specialisation { Id = 9, Name = "Отоларинголог" });
            clinic.AddSpecialization("Gynecologist", new Specialisation { Id = 10, Name = "Гинеколог" });

            var doctor1 = new Doctor
            {
                PassportNumber = "D001",
                LastName = "Смирнов",
                FirstName = "Андрей",
                Patronymic = "Иванович",
                BirthYear = 1970,
                Specializations = new List<Specialisation> {
                    clinic.Specialisations["Cardiologist"]
                },
                ExperienceYears = 15
            };
            clinic.AddDoctor(doctor1);

            var doctor2 = new Doctor
            {
                PassportNumber = "D002",
                LastName = "Коваленко",
                FirstName = "Мария",
                Patronymic = "Петровна",
                BirthYear = 1985,
                Specializations = new List<Specialisation> {
                    clinic.Specialisations["Dentist"]
                },
                ExperienceYears = 8
            };
            clinic.AddDoctor(doctor2);

            var doctor3 = new Doctor
            {
                PassportNumber = "D003",
                LastName = "Петров",
                FirstName = "Сергей",
                Patronymic = "Викторович",
                BirthYear = 1978,
                Specializations = new List<Specialisation> {
                    clinic.Specialisations["Cardiologist"],
                    clinic.Specialisations["Therapist"]
                },
                ExperienceYears = 12
            };
            clinic.AddDoctor(doctor3);

            var doctor4 = new Doctor
            {
                PassportNumber = "D004",
                LastName = "Орлова",
                FirstName = "Елена",
                Patronymic = "Александровна",
                BirthYear = 1982,
                Specializations = new List<Specialisation> {
                    clinic.Specialisations["Neurologist"],
                    clinic.Specialisations["Psychiatrist"]
                },
                ExperienceYears = 10
            };
            clinic.AddDoctor(doctor4);

            var doctor5 = new Doctor
            {
                PassportNumber = "D005",
                LastName = "Волков",
                FirstName = "Дмитрий",
                Patronymic = "Сергеевич",
                BirthYear = 1990,
                Specializations = new List<Specialisation> {
                    clinic.Specialisations["Pediatrician"],
                    clinic.Specialisations["Dermatologist"]
                },
                ExperienceYears = 5
            };
            clinic.AddDoctor(doctor5);

            var doctor6 = new Doctor
            {
                PassportNumber = "D006",
                LastName = "Никитина",
                FirstName = "Ольга",
                Patronymic = "Владимировна",
                BirthYear = 1987,
                Specializations = new List<Specialisation> {
                    clinic.Specialisations["Dermatologist"],
                    clinic.Specialisations["Ophthalmologist"]
                },
                ExperienceYears = 7
            };
            clinic.AddDoctor(doctor6);

            var doctor7 = new Doctor
            {
                PassportNumber = "D007",
                LastName = "Лебедев",
                FirstName = "Алексей",
                Patronymic = "Игоревич",
                BirthYear = 1975,
                Specializations = new List<Specialisation> {
                    clinic.Specialisations["Psychiatrist"],
                    clinic.Specialisations["Neurologist"]
                },
                ExperienceYears = 18
            };
            clinic.AddDoctor(doctor7);

            var doctor8 = new Doctor
            {
                PassportNumber = "D008",
                LastName = "Соколова",
                FirstName = "Ирина",
                Patronymic = "Михайловна",
                BirthYear = 1980,
                Specializations = new List<Specialisation> {
                    clinic.Specialisations["Ophthalmologist"]
                },
                ExperienceYears = 11
            };
            clinic.AddDoctor(doctor8);

            var doctor9 = new Doctor
            {
                PassportNumber = "D009",
                LastName = "Козлов",
                FirstName = "Михаил",
                Patronymic = "Анатольевич",
                BirthYear = 1983,
                Specializations = new List<Specialisation> {
                    clinic.Specialisations["Dentist"]
                },
                ExperienceYears = 9
            };
            clinic.AddDoctor(doctor9);

            var doctor10 = new Doctor
            {
                PassportNumber = "D010",
                LastName = "Григорьева",
                FirstName = "Наталья",
                Patronymic = "Валерьевна",
                BirthYear = 1979,
                Specializations = new List<Specialisation> {
                    clinic.Specialisations["Gynecologist"],
                    clinic.Specialisations["Pediatrician"]
                },
                ExperienceYears = 14
            };
            clinic.AddDoctor(doctor10);

            var appointment1 = new Appointment
            {
                Patient = patient1,
                Doctor = doctor1,
                DateTime = new DateTime(2025, 9, 15, 9, 0, 0),
                RoomNumber = 101,
                IsReturnVisit = false
            };
            clinic.MakeAnAppointment(appointment1);

            var appointment2 = new Appointment
            {
                Patient = patient2,
                Doctor = doctor2,
                DateTime = new DateTime(2025, 9, 10, 10, 30, 0),
                RoomNumber = 205,
                IsReturnVisit = true
            };
            clinic.MakeAnAppointment(appointment2);

            var appointment3 = new Appointment
            {
                Patient = patient3,
                Doctor = doctor3,
                DateTime = new DateTime(2025, 9, 25, 11, 0, 0),
                RoomNumber = 102,
                IsReturnVisit = false
            };
            clinic.MakeAnAppointment(appointment3);

            var appointment4 = new Appointment
            {
                Patient = patient4,
                Doctor = doctor4,
                DateTime = new DateTime(2025, 9, 5, 14, 15, 0),
                RoomNumber = 303,
                IsReturnVisit = false
            };
            clinic.MakeAnAppointment(appointment4);

            var appointment5 = new Appointment
            {
                Patient = patient5,
                Doctor = doctor5,
                DateTime = new DateTime(2025, 9, 18, 9, 30, 0),
                RoomNumber = 303,
                IsReturnVisit = true
            };
            clinic.MakeAnAppointment(appointment5);

            var appointment6 = new Appointment
            {
                Patient = patient6,
                Doctor = doctor6,
                DateTime = new DateTime(2025, 9, 22, 15, 45, 0),
                RoomNumber = 206,
                IsReturnVisit = false
            };
            clinic.MakeAnAppointment(appointment6);

            var appointment7 = new Appointment
            {
                Patient = patient7,
                Doctor = doctor7,
                DateTime = new DateTime(2025, 9, 2, 10, 0, 0),
                RoomNumber = 303,
                IsReturnVisit = true
            };
            clinic.MakeAnAppointment(appointment7);

            var appointment8 = new Appointment
            {
                Patient = patient8,
                Doctor = doctor8,
                DateTime = new DateTime(2025, 9, 8, 13, 20, 0),
                RoomNumber = 207,
                IsReturnVisit = false
            };
            clinic.MakeAnAppointment(appointment8);

            var appointment9 = new Appointment
            {
                Patient = patient9,
                Doctor = doctor9,
                DateTime = new DateTime(2025, 4, 15, 11, 30, 0),
                RoomNumber = 208,
                IsReturnVisit = false
            };
            clinic.MakeAnAppointment(appointment9);

            var appointment10 = new Appointment
            {
                Patient = patient10,
                Doctor = doctor10,
                DateTime = new DateTime(2025, 9, 20, 16, 0, 0),
                RoomNumber = 105,
                IsReturnVisit = true
            };
            clinic.MakeAnAppointment(appointment10);

            var appointment11 = new Appointment
            {
                Patient = patient3,
                Doctor = doctor1,
                DateTime = new DateTime(2025, 9, 25, 9, 0, 0),
                RoomNumber = 101,
                IsReturnVisit = true
            };
            clinic.MakeAnAppointment(appointment11);

            var appointment12 = new Appointment
            {
                Patient = patient2,
                Doctor = doctor3,
                DateTime = new DateTime(2025, 9, 15, 11, 0, 0),
                RoomNumber = 102,
                IsReturnVisit = true
            };
            clinic.MakeAnAppointment(appointment12);

            var appointment13 = new Appointment
            {
                Patient = patient7,
                Doctor = doctor5,
                DateTime = new DateTime(2025, 8, 23, 9, 0, 0),
                RoomNumber = 101,
                IsReturnVisit = true
            };
            clinic.MakeAnAppointment(appointment13);
        }


    }
        
}