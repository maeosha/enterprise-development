using Microsoft.EntityFrameworkCore;
using Clinic.DataBase;
using Clinic.Api.Services;
using Clinic.Models.Entities;
using Clinic.Models.Enums;
using Microsoft.AspNetCore.Http;

namespace Clinic.Tests;

/// <summary>
/// Базовый класс для тестирования Entity Framework контекста с InMemory Database
/// </summary>
public abstract class DatabaseTestBase(AnalyticsServices testServices) : IClassFixture<ClinicDbContext>
{
    [Fact]
    public void GetDoctorsWithExperience_WhenExperienceAtLeast10Years_ReturnsExperiencedDoctorsOrderedByName()
    {
        var doctorsWithExperience10OrMore = new List<int> {1, 2, 3, 4, 5, 6, 7, 9, 10};
        var result = testServices.GetDoctorsWithExperience10YearsOrMore().Select(d => d.Id);
        Assert.Equal(doctorsWithExperience10OrMore, result);
    }

    [Fact]
    public void GetPatientsByDoctor_WhenDoctorIsSpecified_ReturnsPatientsOrderedByName()
    {
        var doctorId = 3;
        var patientsByDoctor = new List<int> {3};

        var result = testServices.GetPatientsByDoctorOrderedByFullName(doctorId).Select(p => p.Id);
        Assert.Equal(patientsByDoctor, result);
    }

    [Fact]
    public void CountAppointments_WhenRepeatVisitsInLastMonth_ReturnsCorrectCount()
    {
        var returnVisits = 2;
        var result = testServices.GetReturnVisitsCountLastMonth();

        Assert.Equal(returnVisits, result);
    }

    [Fact]
    public void GetPatients_WhenOver30WithMultipleDoctors_ReturnsPatientsOrderedByBirthDate()
    {
        var patientsOver30WithMultipleDoctors = new List<int> {1, 3};
        var result = testServices.GetPatientsOver30WithMultipleDoctorsOrderedByBirthDate().Select(p => p.Id);

        Assert.Equal(patientsOver30WithMultipleDoctors, result);
    }

    [Fact]
    public void GetAppointments_WhenInSpecificRoomCurrentMonth_ReturnsAppointmentsOrderedByDateTime()
    {
        var roomNumber = 101;
        var appointmentsInRoomCurrentMonth = new List<int> {1};

        var result = testServices.GetAppointmentsInRoomForCurrentMonth(roomNumber).Select(a => a.Id);

        Assert.Equal(appointmentsInRoomCurrentMonth, result);

    }
}
