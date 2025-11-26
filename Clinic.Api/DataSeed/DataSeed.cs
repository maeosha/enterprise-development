using Clinic.Api.DataBase;
using Clinic.Models.Entities;
using Clinic.Models.Enums;

namespace Clinic.Api.DataSeed;

public class DataSeed
{
    public void TestDataSeed(IClinicDataBase _db)
    {
        var patient1 = new Patient
        {
            Id = 1,
            PassportNumber = "P001",
            LastName = "Иванов",
            FirstName = "Иван",
            Patronymic = "Иванович",
            BloodGroup = BloodGroup.A,
            RhesusFactor = RhesusFactor.Positive,
            Address = "г. Москва, ул. Ленина, д. 10",
            Gender = Gender.Male,
            BirthDate = new DateOnly(1985, 5, 20),
            PhoneNumber = "+79991234567"
        };
        _db.AddPatient(patient1);

        var patient2 = new Patient
        {
            Id = 2,
            PassportNumber = "P002",
            LastName = "Петрова",
            FirstName = "Мария",
            Patronymic = "Сергеевна",
            BloodGroup = BloodGroup.B,
            RhesusFactor = RhesusFactor.Positive,
            Address = "г. Санкт-Петербург, ул. Пушкина, д. 25",
            Gender = Gender.Female,
            BirthDate = new DateOnly(1990, 8, 15),
            PhoneNumber = "+79992345678"
        };
        _db.AddPatient(patient2);

        var patient3 = new Patient
        {
            Id = 3,
            PassportNumber = "P003",
            LastName = "Сидоров",
            FirstName = "Алексей",
            Patronymic = "Петрович",
            BloodGroup = BloodGroup.O,
            RhesusFactor = RhesusFactor.Negative,
            Address = "г. Екатеринбург, ул. Мира, д. 15",
            Gender = Gender.Male,
            BirthDate = new DateOnly(1978, 12, 3),
            PhoneNumber = "+79993456789"
        };
        _db.AddPatient(patient3);

        var patient4 = new Patient
        {
            Id = 4,
            PassportNumber = "P004",
            LastName = "Кузнецова",
            FirstName = "Ольга",
            Patronymic = "Владимировна",
            BloodGroup = BloodGroup.AB,
            RhesusFactor = RhesusFactor.Positive,
            Address = "г. Новосибирск, ул. Советская, д. 8",
            Gender = Gender.Female,
            BirthDate = new DateOnly(1995, 3, 10),
            PhoneNumber = "+79994567890"
        };
        _db.AddPatient(patient4);

        var patient5 = new Patient
        {
            Id = 5,
            PassportNumber = "P005",
            LastName = "Васильев",
            FirstName = "Дмитрий",
            Patronymic = "Александрович",
            BloodGroup = BloodGroup.A,
            RhesusFactor = RhesusFactor.Negative,
            Address = "г. Казань, ул. Гагарина, д. 12",
            Gender = Gender.Male,
            BirthDate = new DateOnly(1982, 7, 28),
            PhoneNumber = "+79995678901"
        };
        _db.AddPatient(patient5);

        var patient6 = new Patient
        {
            Id = 6,
            PassportNumber = "P006",
            LastName = "Николаева",
            FirstName = "Елена",
            Patronymic = "Игоревна",
            BloodGroup = BloodGroup.O,
            RhesusFactor = RhesusFactor.Positive,
            Address = "г. Нижний Новгород, ул. Лермонтова, д. 30",
            Gender = Gender.Female,
            BirthDate = new DateOnly(1988, 11, 5),
            PhoneNumber = "+79996789012"
        };
        _db.AddPatient(patient6);

        var patient7 = new Patient
        {
            Id = 7,
            PassportNumber = "P007",
            LastName = "Морозов",
            FirstName = "Сергей",
            Patronymic = "Викторович",
            BloodGroup = BloodGroup.B,
            RhesusFactor = RhesusFactor.Positive,
            Address = "г. Самара, ул. Чехова, д. 7",
            Gender = Gender.Male,
            BirthDate = new DateOnly(1975, 1, 18),
            PhoneNumber = "+79997890123"
        };
        _db.AddPatient(patient7);

        var patient8 = new Patient
        {
            Id = 8,
            PassportNumber = "P008",
            LastName = "Орлова",
            FirstName = "Анна",
            Patronymic = "Дмитриевна",
            BloodGroup = BloodGroup.AB,
            RhesusFactor = RhesusFactor.Negative,
            Address = "г. Ростов-на-Дону, ул. Кирова, д. 18",
            Gender = Gender.Female,
            BirthDate = new DateOnly(1992, 9, 22),
            PhoneNumber = "+79998901234"
        };
        _db.AddPatient(patient8);

        var patient9 = new Patient
        {
            Id = 9,
            PassportNumber = "P009",
            LastName = "Павлов",
            FirstName = "Михаил",
            Patronymic = "Олегович",
            BloodGroup = BloodGroup.O,
            RhesusFactor = RhesusFactor.Positive,
            Address = "г. Уфа, ул. Горького, д. 22",
            Gender = Gender.Male,
            BirthDate = new DateOnly(1980, 4, 14),
            PhoneNumber = "+79999012345"
        };
        _db.AddPatient(patient9);

        var patient10 = new Patient
        {
            Id = 10,
            PassportNumber = "P010",
            LastName = "Федорова",
            FirstName = "Татьяна",
            Patronymic = "Николаевна",
            BloodGroup = BloodGroup.A,
            RhesusFactor = RhesusFactor.Positive,
            Address = "г. Красноярск, ул. Ленина, д. 5",
            Gender = Gender.Female,
            BirthDate = new DateOnly(1987, 6, 30),
            PhoneNumber = "+79990123456"
        };
        _db.AddPatient(patient10);

        var specialization1 = new Specialization { Id = 1, Name = "Терапевт" };
        _db.AddSpecialization(specialization1);

        var specialization2 = new Specialization { Id = 2, Name = "Стоматолог" };
        _db.AddSpecialization(specialization2);

        var specialization3 = new Specialization { Id = 3, Name = "Кардиолог" };
        _db.AddSpecialization(specialization3);

        var specialization4 = new Specialization { Id = 4, Name = "Невролог" };
        _db.AddSpecialization(specialization4);

        var specialization5 = new Specialization { Id = 5, Name = "Педиатр" };
        _db.AddSpecialization(specialization5);

        var specialization6 = new Specialization { Id = 6, Name = "Дерматолог" };
        _db.AddSpecialization(specialization6);

        var specialization7 = new Specialization { Id = 7, Name = "Психиатр" };
        _db.AddSpecialization(specialization7);

        var specialization8 = new Specialization { Id = 8, Name = "Офтальмолог" };
        _db.AddSpecialization(specialization8);

        var specialization9 = new Specialization { Id = 9, Name = "Гинеколог" };
        _db.AddSpecialization(specialization9);

        var doctor1 = new Doctor
        {
            Id = 1,
            PassportNumber = "D001",
            LastName = "Смирнов",
            FirstName = "Андрей",
            Patronymic = "Николаевич",
            Gender = Gender.Male,
            BirthDate = new DateOnly(1980, 1, 15),
            Specializations = new List<Specialization> { specialization1, specialization3 },
            ExperienceYears = 10,
            PhoneNumber = "+79876543210"
        };
        _db.AddDoctor(doctor1);

        var doctor2 = new Doctor
        {
            Id = 2,
            PassportNumber = "D002",
            LastName = "Егорова",
            FirstName = "Екатерина",
            Patronymic = "Александровна",
            Gender = Gender.Female,
            BirthDate = new DateOnly(1985, 4, 20),
            Specializations = new List<Specialization> { specialization2, specialization6 },
            ExperienceYears = 8,
            PhoneNumber = "+79876543211"
        };
        _db.AddDoctor(doctor2);

        var doctor3 = new Doctor
        {
            Id = 3,
            PassportNumber = "D003",
            LastName = "Петров",
            FirstName = "Дмитрий",
            Patronymic = "Сергеевич",
            Gender = Gender.Male,
            BirthDate = new DateOnly(1978, 7, 12),
            Specializations = new List<Specialization> { specialization4, specialization7 },
            ExperienceYears = 15,
            PhoneNumber = "+79876543212"
        };
        _db.AddDoctor(doctor3);

        var doctor4 = new Doctor
        {
            Id = 4,
            PassportNumber = "D004",
            LastName = "Соколова",
            FirstName = "Ольга",
            Patronymic = "Викторовна",
            Gender = Gender.Female,
            BirthDate = new DateOnly(1982, 11, 5),
            Specializations = new List<Specialization> { specialization1, specialization5 },
            ExperienceYears = 12,
            PhoneNumber = "+79876543213"
        };
        _db.AddDoctor(doctor4);

        var doctor5 = new Doctor
        {
            Id = 5,
            PassportNumber = "D005",
            LastName = "Кузнецов",
            FirstName = "Михаил",
            Patronymic = "Андреевич",
            Gender = Gender.Male,
            BirthDate = new DateOnly(1990, 3, 25),
            Specializations = new List<Specialization> { specialization3, specialization8 },
            ExperienceYears = 6,
            PhoneNumber = "+79876543214"
        };
        _db.AddDoctor(doctor5);

        var doctor6 = new Doctor
        {
            Id = 6,
            PassportNumber = "D006",
            LastName = "Иванова",
            FirstName = "Анна",
            Patronymic = "Дмитриевна",
            Gender = Gender.Female,
            BirthDate = new DateOnly(1987, 9, 18),
            Specializations = new List<Specialization> { specialization2, specialization9 },
            ExperienceYears = 9,
            PhoneNumber = "+79876543215"
        };
        _db.AddDoctor(doctor6);

        var doctor7 = new Doctor
        {
            Id = 7,
            PassportNumber = "D007",
            LastName = "Морозов",
            FirstName = "Сергей",
            Patronymic = "Владимирович",
            Gender = Gender.Male,
            BirthDate = new DateOnly(1975, 12, 8),
            Specializations = new List<Specialization> { specialization4, specialization9 },
            ExperienceYears = 20,
            PhoneNumber = "+79876543216"
        };
        _db.AddDoctor(doctor7);

        var doctor8 = new Doctor
        {
            Id = 8,
            PassportNumber = "D008",
            LastName = "Федорова",
            FirstName = "Татьяна",
            Patronymic = "Игоревна",
            Gender = Gender.Female,
            BirthDate = new DateOnly(1983, 6, 30),
            Specializations = new List<Specialization> { specialization5, specialization7 },
            ExperienceYears = 11,
            PhoneNumber = "+79876543217"
        };
        _db.AddDoctor(doctor8);

        var doctor9 = new Doctor
        {
            Id = 9,
            PassportNumber = "D009",
            LastName = "Никитин",
            FirstName = "Алексей",
            Patronymic = "Павлович",
            Gender = Gender.Male,
            BirthDate = new DateOnly(1988, 2, 14),
            Specializations = new List<Specialization> { specialization6, specialization8 },
            ExperienceYears = 7,
            PhoneNumber = "+79876543218"
        };
        _db.AddDoctor(doctor9);

        var doctor10 = new Doctor
        {
            Id = 10,
            PassportNumber = "D010",
            LastName = "Орлова",
            FirstName = "Марина",
            Patronymic = "Сергеевна",
            Gender = Gender.Female,
            BirthDate = new DateOnly(1981, 8, 22),
            Specializations = new List<Specialization> { specialization1, specialization2, specialization3 },
            ExperienceYears = 14,
            PhoneNumber = "+79876543219"
        };
        _db.AddDoctor(doctor10);

        var appointment1 = new Appointment
        {
            Id = 1,
            PatientId = patient1.Id,
            PatientFullName = patient1.GetFullName(),
            DoctorId = doctor1.Id,
            DoctorFullName = doctor1.GetFullName(),
            DateTime = new DateTime(2025, 1, 10, 9, 0, 0),
            RoomNumber = 101,
            IsReturnVisit = false
        };
        _db.AddAppointment(appointment1);

        var appointment2 = new Appointment
        {
            Id = 2,
            PatientId = patient2.Id,
            PatientFullName = patient2.GetFullName(),
            DoctorId = doctor2.Id,
            DoctorFullName = doctor2.GetFullName(),
            DateTime = new DateTime(2025, 1, 10, 9, 30, 0),
            RoomNumber = 102,
            IsReturnVisit = false
        };
        _db.AddAppointment(appointment2);

        var appointment3 = new Appointment
        {
            Id = 3,
            PatientId = patient3.Id,
            PatientFullName = patient3.GetFullName(),
            DoctorId = doctor3.Id,
            DoctorFullName = doctor3.GetFullName(),
            DateTime = new DateTime(2025, 1, 10, 10, 0, 0),
            RoomNumber = 103,
            IsReturnVisit = true
        };
        _db.AddAppointment(appointment3);

        var appointment4 = new Appointment
        {
            Id = 4,
            PatientId = patient4.Id,
            PatientFullName = patient4.GetFullName(),
            DoctorId = doctor4.Id,
            DoctorFullName = doctor4.GetFullName(),
            DateTime = new DateTime(2025, 1, 10, 10, 30, 0),
            RoomNumber = 104,
            IsReturnVisit = false
        };
        _db.AddAppointment(appointment4);

        var appointment5 = new Appointment
        {
            Id = 5,
            PatientId = patient5.Id,
            PatientFullName = patient5.GetFullName(),
            DoctorId = doctor5.Id,
            DoctorFullName = doctor5.GetFullName(),
            DateTime = new DateTime(2025, 1, 10, 11, 0, 0),
            RoomNumber = 105,
            IsReturnVisit = true
        };
        _db.AddAppointment(appointment5);

        var appointment6 = new Appointment
        {
            Id = 6,
            PatientId = patient6.Id,
            PatientFullName = patient6.GetFullName(),
            DoctorId = doctor6.Id,
            DoctorFullName = doctor6.GetFullName(),
            DateTime = new DateTime(2025, 1, 10, 11, 30, 0),
            RoomNumber = 201,
            IsReturnVisit = false
        };
        _db.AddAppointment(appointment6);

        var appointment7 = new Appointment
        {
            Id = 7,
            PatientId = patient7.Id,
            PatientFullName = patient7.GetFullName(),
            DoctorId = doctor7.Id,
            DoctorFullName = doctor7.GetFullName(),
            DateTime = new DateTime(2025, 1, 10, 12, 0, 0),
            RoomNumber = 202,
            IsReturnVisit = true
        };
        _db.AddAppointment(appointment7);

        var appointment8 = new Appointment
        {
            Id = 8,
            PatientId = patient8.Id,
            PatientFullName = patient8.GetFullName(),
            DoctorId = doctor8.Id,
            DoctorFullName = doctor8.GetFullName(),
            DateTime = new DateTime(2025, 1, 10, 12, 30, 0),
            RoomNumber = 203,
            IsReturnVisit = false
        };
        _db.AddAppointment(appointment8);

        var appointment9 = new Appointment
        {
            Id = 9,
            PatientId = patient9.Id,
            PatientFullName = patient9.GetFullName(),
            DoctorId = doctor9.Id,
            DoctorFullName = doctor9.GetFullName(),
            DateTime = new DateTime(2025, 1, 10, 13, 0, 0),
            RoomNumber = 204,
            IsReturnVisit = false
        };
        _db.AddAppointment(appointment9);

        var appointment10 = new Appointment
        {
            Id = 10,
            PatientId = patient10.Id,
            PatientFullName = patient10.GetFullName(),
            DoctorId = doctor10.Id,
            DoctorFullName = doctor10.GetFullName(),
            DateTime = new DateTime(2025, 1, 10, 13, 30, 0),
            RoomNumber = 205,
            IsReturnVisit = true
        };
        _db.AddAppointment(appointment10);

        var appointment11 = new Appointment
        {
            Id = 11,
            PatientId = patient1.Id,
            PatientFullName = patient1.GetFullName(),
            DoctorId = doctor2.Id,
            DoctorFullName = doctor2.GetFullName(),
            DateTime = new DateTime(2025, 1, 11, 9, 0, 0),
            RoomNumber = 101,
            IsReturnVisit = true
        };
        _db.AddAppointment(appointment11);

        var appointment12 = new Appointment
        {
            Id = 12,
            PatientId = patient3.Id,
            PatientFullName = patient3.GetFullName(),
            DoctorId = doctor1.Id,
            DoctorFullName = doctor1.GetFullName(),
            DateTime = new DateTime(2025, 1, 11, 9, 30, 0),
            RoomNumber = 102,
            IsReturnVisit = false
        };
        _db.AddAppointment(appointment12);
    }
}