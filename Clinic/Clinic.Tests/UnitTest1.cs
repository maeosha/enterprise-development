using System;
using Clinic.Tests.DataSeed;
using Clinic.Models;
using Clinic.Models.Entities;

namespace Clinic.Tests;

/// <summary>
/// A set of integration tests verifying the business logic of the clinic system.
/// Uses the <see cref="ClinicDataSeed"/> fixture to initialize test data.
/// All tests validate filtering and aggregation logic for doctors, patients, and appointments.
/// </summary>
public class ClinicTest(ClinicDataSeed clinicDataSeed) : IClassFixture<ClinicDataSeed>
{
    private readonly ClinicInfo clinic = clinicDataSeed.clinic;

    /// <summary>
    /// Verifies that only doctors with 10 or more years of experience are returned.
    /// Compares the full names from the result with the expected list.
    /// </summary>
    [Fact]
    public void GetDoctors_ReturnsDoctorsWith10OrMoreYearsOfExperience()
    {
        var doctorsWith10OrMoreYearsOfExperience = new List<string> {
                "Смирнов Андрей Иванович",
                "Петров Сергей Викторович",
                "Орлова Елена Александровна",
                "Лебедев Алексей Игоревич",
                "Соколова Ирина Михайловна",
                "Григорьева Наталья Валерьевна"
            };

        var resDoctors = clinic.Doctors
            .Where(d => d.ExperienceYears >= 10)
            .Select(d => d.GetFullName())
            .ToList();

        Assert.Equal(doctorsWith10OrMoreYearsOfExperience, resDoctors);
    }

    /// <summary>
    /// Ensures that all patients who have appointments with the target doctor (Id = 1) are returned.
    /// Patients are selected uniquely and sorted by full name.
    /// </summary>
    [Fact]
    public void GetTargerDoctor_ReturnsPatientsWhoHaveAppointmentWithTargetDoctor()
    {
        var targetDoctor = clinic.Doctors.First(d => d.Id == 1);
        var patientsWhoHaveAppointmentWithTargetDocor = new List<string> {
                "Иванов Иван Иванович",
                "Сидоров Алексей Петрович"
            };

        var resPatients = clinic.Appointments
            .Where(d => d.Doctor == targetDoctor)
            .Select(p => p.Patient)
            .Distinct()
            .Select(p => p.GetFullName())
            .OrderBy(n => n)
            .ToList();

        Assert.Equal(patientsWhoHaveAppointmentWithTargetDocor, resPatients);
    }

    /// <summary>
    /// Counts the number of return visits (IsReturnVisit = true) in the last month
    /// relative to September 4, 2025. Expected count: 7.
    /// </summary>
    [Fact]
    public void GetAppointmentInTheLastMonths_ReturnsRepeatedAppointment()
    {
        var countRepeatedAppointments = 7;

        var currentDate = new DateTime(2025, 9, 4);
        var lastMonth = currentDate.AddMonths(-1);

        var resCount = clinic.Appointments
            .Where(a => a.DateTime >= lastMonth && a.IsReturnVisit)
            .Count();

        Assert.Equal(countRepeatedAppointments, resCount);
    }

    /// <summary>
    /// Finds patients over 30 years old (as of November 4, 2025) who have appointments
    /// with multiple doctors. Results are ordered by birth date (oldest first).
    /// </summary>
    [Fact]
    public void GetPationsOver30_ReturnsPationsWhoHaveAppointmentWithSeveralDoctors()
    {
        var pationsWhoHaveAppointmentWithSeveralDoctors = new List<string>
            {
                "Морозов Сергей Викторович",
                "Сидоров Алексей Петрович",
                "Петрова Мария Сергеевна"
            };

        var currentDate = new DateOnly(2025, 11, 4);
        var age30 = currentDate.AddYears(-30);

        var resPatients = clinic.Patients
            .Where(a => a.BirthDate <= age30)
            .Where(p => clinic.Appointments.Count(a => a.Patient.PassportNumber == p.PassportNumber) > 1)
            .OrderBy(d => d.BirthDate)
            .Select(p => p.GetFullName())
            .ToList();

        Assert.Equal(pationsWhoHaveAppointmentWithSeveralDoctors, resPatients);
    }

    /// <summary>
    /// Counts the number of appointments in room 303 during the last month
    /// relative to September 4, 2025.. Expected count: 3.
    /// </summary>
    [Fact]
    public void GetTargetRoom_ReturnsCountAppointmentsInTheLastMonthThatTookPlaceInTargetRoom()
    {
        var countAppointmentsInTheLastMonthThatTookPlaceInTargetRoom = 3;

        var targetRoom = 303;
        var currentDate = new DateTime(2025, 9, 4);
        var lastMonth = currentDate.AddMonths(-1);

        var resCount = clinic.Appointments
            .Where(a => a.RoomNumber == targetRoom &&
                   a.DateTime >= lastMonth)
            .Count();

        Assert.Equal(countAppointmentsInTheLastMonthThatTookPlaceInTargetRoom, resCount);
    }
}
