using Clinic.Models;
using Clinic.Models.Entities;
using Clinic.Models.Enums;
using Clinic.Models.ReferenceBooks;

namespace Clinic.Tests.DataSeed;

/// <summary>
/// Represents a static helper class responsible for seeding initial clinic data, 
/// such as doctors, patients, specializations, and appointments, into a <see cref="ClinicInfo"/> instance.
/// </summary>
public class ClinicDataSeed
{
    public ClinicInfo clinic{ get; set; } = new ClinicInfo();

    public ClinicDataSeed()
    {
        var patient1 = new Patient
        {
            Id = 1,
            PassportNumber = "P001",
            LastName = "Иванов",
            FirstName = "Иван",
            Patronymic = "Иванович",
            Gender = Gender.Male,
            BirthDate = new DateOnly(1985, 5, 20),
            Address = "г. Москва, ул. Ленина, д. 10",
            BloodGroup = BloodGroup.A,
            RhesusFactor = RhesusFactor.Positive,
            PhoneNumber = "+79991234567"
        };
        clinic.AddPatient(patient1);

        var patient2 = new Patient
        {
            Id = 2,
            PassportNumber = "P002",
            LastName = "Петрова",
            FirstName = "Мария",
            Patronymic = "Сергеевна",
            Gender = Gender.Female,
            BirthDate = new DateOnly(1990, 8, 15),
            Address = "г. Санкт-Петербург, ул. Пушкина, д. 25",
            BloodGroup = BloodGroup.B,
            RhesusFactor = RhesusFactor.Positive,
            PhoneNumber = "+79992345678"
        };
        clinic.AddPatient(patient2);

        var patient3 = new Patient
        {
            Id = 3,
            PassportNumber = "P003",
            LastName = "Сидоров",
            FirstName = "Алексей",
            Patronymic = "Петрович",
            Gender = Gender.Male,
            BirthDate = new DateOnly(1978, 12, 3),
            Address = "г. Екатеринбург, ул. Мира, д. 15",
            BloodGroup = BloodGroup.O,
            RhesusFactor = RhesusFactor.Negative,
            PhoneNumber = "+79993456789"
        };
        clinic.AddPatient(patient3);

        var patient4 = new Patient
        {
            Id = 4,
            PassportNumber = "P004",
            LastName = "Кузнецова",
            FirstName = "Ольга",
            Patronymic = "Владимировна",
            Gender = Gender.Female,
            BirthDate = new DateOnly(1995, 3, 10),
            Address = "г. Новосибирск, ул. Советская, д. 8",
            BloodGroup = BloodGroup.AB,
            RhesusFactor = RhesusFactor.Positive,
            PhoneNumber = "+79994567890"
        };
        clinic.AddPatient(patient4);

        var patient5 = new Patient
        {
            Id = 5,
            PassportNumber = "P005",
            LastName = "Васильев",
            FirstName = "Дмитрий",
            Patronymic = "Александрович",
            Gender = Gender.Male,
            BirthDate = new DateOnly(1982, 7, 28),
            Address = "г. Казань, ул. Гагарина, д. 12",
            BloodGroup = BloodGroup.A,
            RhesusFactor = RhesusFactor.Negative,
            PhoneNumber = "+79995678901"
        };
        clinic.AddPatient(patient5);

        var patient6 = new Patient
        {
            Id = 6,
            PassportNumber = "P006",
            LastName = "Николаева",
            FirstName = "Елена",
            Patronymic = "Игоревна",
            Gender = Gender.Female,
            BirthDate = new DateOnly(1988, 11, 5),
            Address = "г. Нижний Новгород, ул. Лермонтова, д. 30",
            BloodGroup = BloodGroup.O,
            RhesusFactor = RhesusFactor.Positive,
            PhoneNumber = "+79996789012"
        };
        clinic.AddPatient(patient6);

        var patient7 = new Patient
        {
            Id = 7,
            PassportNumber = "P007",
            LastName = "Морозов",
            FirstName = "Сергей",
            Patronymic = "Викторович",
            Gender = Gender.Male,
            BirthDate = new DateOnly(1975, 1, 18),
            Address = "г. Самара, ул. Чехова, д. 7",
            BloodGroup = BloodGroup.B,
            RhesusFactor = RhesusFactor.Positive,
            PhoneNumber = "+79997890123"
        };
        clinic.AddPatient(patient7);

        var patient8 = new Patient
        {
            Id = 8,
            PassportNumber = "P008",
            LastName = "Орлова",
            FirstName = "Анна",
            Patronymic = "Дмитриевна",
            Gender = Gender.Female,
            BirthDate = new DateOnly(1992, 9, 22),
            Address = "г. Ростов-на-Дону, ул. Кирова, д. 18",
            BloodGroup = BloodGroup.AB,
            RhesusFactor = RhesusFactor.Negative,
            PhoneNumber = "+79998901234"
        };
        clinic.AddPatient(patient8);

        var patient9 = new Patient
        {
            Id = 9,
            PassportNumber = "P009",
            LastName = "Павлов",
            FirstName = "Михаил",
            Patronymic = "Олегович",
            Gender = Gender.Male,
            BirthDate = new DateOnly(1980, 4, 14),
            Address = "г. Уфа, ул. Горького, д. 22",
            BloodGroup = BloodGroup.O,
            RhesusFactor = RhesusFactor.Positive,
            PhoneNumber = "+79999012345"
        };
        clinic.AddPatient(patient9);

        var patient10 = new Patient
        {
            Id = 10,
            PassportNumber = "P010",
            LastName = "Федорова",
            FirstName = "Татьяна",
            Patronymic = "Николаевна",
            Gender = Gender.Female,
            BirthDate = new DateOnly(1987, 6, 30),
            Address = "г. Красноярск, ул. Ленина, д. 5",
            BloodGroup = BloodGroup.A,
            RhesusFactor = RhesusFactor.Positive,
            PhoneNumber = "+79990123456"
        };
        clinic.AddPatient(patient10);
        clinic.AddSpecialization("Therapist", new Specialization { Id = 1, Name = "Терапевт" });
        clinic.AddSpecialization("Dentist", new Specialization { Id = 2, Name = "Стоматолог" });
        clinic.AddSpecialization("Cardiologist", new Specialization { Id = 3, Name = "Кардиолог" });
        clinic.AddSpecialization("Neurologist", new Specialization { Id = 4, Name = "Невролог" });
        clinic.AddSpecialization("Pediatrician", new Specialization { Id = 5, Name = "Педиатр" });
        clinic.AddSpecialization("Dermatologist", new Specialization { Id = 6, Name = "Дерматолог" });
        clinic.AddSpecialization("Psychiatrist", new Specialization { Id = 7, Name = "Психиатр" });
        clinic.AddSpecialization("Ophthalmologist", new Specialization { Id = 8, Name = "Офтальмолог" });
        clinic.AddSpecialization("ENTSpecialist", new Specialization { Id = 9, Name = "Отоларинголог" });
        clinic.AddSpecialization("Gynecologist", new Specialization { Id = 10, Name = "Гинеколог" });

        var doctor1 = new Doctor
        {
            Id = 1,
            PassportNumber = "D001",
            LastName = "Смирнов",
            FirstName = "Андрей",
            Patronymic = "Иванович",
            Gender = Gender.Male,
            BirthDate = new DateOnly(1970, 3, 18),
            Specializations = new List<Specialization> {
                clinic.Specializations["Cardiologist"]
            },
            ExperienceYears = 15
        };
        clinic.AddDoctor(doctor1);

        var doctor2 = new Doctor
        {
            Id = 2,
            PassportNumber = "D002",
            LastName = "Коваленко",
            FirstName = "Мария",
            Patronymic = "Петровна",
            Gender = Gender.Female,
            BirthDate = new DateOnly(1985, 6, 12),
            Specializations = new List<Specialization> {
                clinic.Specializations["Dentist"]
            },
            ExperienceYears = 8
        };
        clinic.AddDoctor(doctor2);

        var doctor3 = new Doctor
        {
            Id = 3,
            PassportNumber = "D003",
            LastName = "Петров",
            FirstName = "Сергей",
            Patronymic = "Викторович",
            Gender = Gender.Male,
            BirthDate = new DateOnly(1978, 9, 25),
            Specializations = new List<Specialization> {
                clinic.Specializations["Cardiologist"],
                clinic.Specializations["Therapist"]
            },
            ExperienceYears = 12
        };
        clinic.AddDoctor(doctor3);

        var doctor4 = new Doctor
        {
            Id = 4,
            PassportNumber = "D004",
            LastName = "Орлова",
            FirstName = "Елена",
            Patronymic = "Александровна",
            Gender = Gender.Female,
            BirthDate = new DateOnly(1982, 11, 7),
            Specializations = new List<Specialization> {
                clinic.Specializations["Neurologist"],
                clinic.Specializations["Psychiatrist"]
            },
            ExperienceYears = 10
        };
        clinic.AddDoctor(doctor4);

        var doctor5 = new Doctor
        {
            Id = 5,
            PassportNumber = "D005",
            LastName = "Волков",
            FirstName = "Дмитрий",
            Patronymic = "Сергеевич",
            Gender = Gender.Male,
            BirthDate = new DateOnly(1990, 2, 14),
            Specializations = new List<Specialization> {
                clinic.Specializations["Pediatrician"],
                clinic.Specializations["Dermatologist"]
            },
            ExperienceYears = 5
        };
        clinic.AddDoctor(doctor5);

        var doctor6 = new Doctor
        {
            Id = 6,
            PassportNumber = "D006",
            LastName = "Никитина",
            FirstName = "Ольга",
            Patronymic = "Владимировна",
            Gender = Gender.Female,
            BirthDate = new DateOnly(1987, 8, 30),
            Specializations = new List<Specialization> {
                clinic.Specializations["Dermatologist"],
                clinic.Specializations["Ophthalmologist"]
            },
            ExperienceYears = 7
        };
        clinic.AddDoctor(doctor6);

        var doctor7 = new Doctor
        {
            Id = 7,
            PassportNumber = "D007",
            LastName = "Лебедев",
            FirstName = "Алексей",
            Patronymic = "Игоревич",
            Gender = Gender.Male,
            BirthDate = new DateOnly(1975, 4, 5),
            Specializations = new List<Specialization> {
                clinic.Specializations["Psychiatrist"],
                clinic.Specializations["Neurologist"]
            },
            ExperienceYears = 18
        };
        clinic.AddDoctor(doctor7);

        var doctor8 = new Doctor
        {
            Id = 8,
            PassportNumber = "D008",
            LastName = "Соколова",
            FirstName = "Ирина",
            Patronymic = "Михайловна",
            Gender = Gender.Female,
            BirthDate = new DateOnly(1980, 10, 19),
            Specializations = new List<Specialization> {
                clinic.Specializations["Ophthalmologist"]
            },
            ExperienceYears = 11
        };
        clinic.AddDoctor(doctor8);

        var doctor9 = new Doctor
        {
            Id = 9,
            PassportNumber = "D009",
            LastName = "Козлов",
            FirstName = "Михаил",
            Patronymic = "Анатольевич",
            Gender = Gender.Male,
            BirthDate = new DateOnly(1983, 7, 22),
            Specializations = new List<Specialization> {
                clinic.Specializations["Dentist"]
            },
            ExperienceYears = 9
        };
        clinic.AddDoctor(doctor9);

        var doctor10 = new Doctor
        {
            Id = 10,
            PassportNumber = "D010",
            LastName = "Григорьева",
            FirstName = "Наталья",
            Patronymic = "Валерьевна",
            Gender = Gender.Female,
            BirthDate = new DateOnly(1979, 12, 1),
            Specializations = new List<Specialization> {
                clinic.Specializations["Gynecologist"],
                clinic.Specializations["Pediatrician"]
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
