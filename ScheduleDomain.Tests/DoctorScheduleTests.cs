using ScheduleDomain.Entities;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace ScheduleDomain.Tests;

public class DoctorScheduleTests
{
    [Fact]
    public void Create_ShouldInitializeProperties()
    {
        // Arrange
        var doctorId = Guid.NewGuid();
        var date = DateTime.Now.AddDays(1);
        var startTime = TimeSpan.FromHours(9);
        var finishTime = TimeSpan.FromHours(17);

        // Act
        var schedule = DoctorSchedule.Create(doctorId, date, startTime, finishTime);

        // Assert
        Assert.That(schedule.DoctorId, Is.EqualTo(doctorId));
        Assert.That(schedule.Date, Is.EqualTo(date));
        Assert.That(schedule.StartTime, Is.EqualTo(startTime));
        Assert.That(schedule.FinishTime, Is.EqualTo(finishTime));
        Assert.Null(schedule.PatientId);
    }

    [Fact]
    public void SetDate_ShouldThrowException_WhenDateIsInThePast()
    {
        // Arrange
        var schedule = DoctorSchedule.Create(Guid.NewGuid(), DateTime.Now, TimeSpan.Zero, TimeSpan.Zero);

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => schedule.SetDate(DateTime.Now.AddDays(-1)));
        Assert.That(exception.Message, Is.EqualTo("Horário não pode estar no passado!"));
    }

    [Fact]
    public void SetPatient_ShouldSetPatientId()
    {
        // Arrange
        var schedule = DoctorSchedule.Create(Guid.NewGuid(), DateTime.Now.AddDays(1), TimeSpan.Zero, TimeSpan.Zero);
        var patientId = Guid.NewGuid();

        // Act
        schedule.SetPatient(patientId);

        // Assert
        Assert.That(schedule.PatientId, Is.EqualTo(patientId));
    }

    [Fact]
    public void ExcludePatient_ShouldSetPatientIdToNull()
    {
        // Arrange
        var schedule = DoctorSchedule.Create(Guid.NewGuid(), DateTime.Now.AddDays(1), TimeSpan.Zero, TimeSpan.Zero);
        var patientId = Guid.NewGuid();
        schedule.SetPatient(patientId);

        // Act
        schedule.ExcludePatinent();

        // Assert
        Assert.Null(schedule.PatientId);
    }

    [Fact]
    public void SetFinishTime_ShouldUpdateFinishTime()
    {
        // Arrange
        var schedule = DoctorSchedule.Create(Guid.NewGuid(), DateTime.Now.AddDays(1), TimeSpan.FromHours(9), TimeSpan.FromHours(17));
        var newFinishTime = TimeSpan.FromHours(18);

        // Act
        schedule.SetFinishTime(newFinishTime);

        // Assert
        Assert.That(schedule.FinishTime, Is.EqualTo(newFinishTime));
    }

    [Fact]
    public void SetStartTime_ShouldUpdateStartTime()
    {
        // Arrange
        var schedule = DoctorSchedule.Create(Guid.NewGuid(), DateTime.Now.AddDays(1), TimeSpan.FromHours(9), TimeSpan.FromHours(17));
        var newStartTime = TimeSpan.FromHours(8);

        // Act
        schedule.SetStartTime(newStartTime);

        // Assert
        Assert.That(schedule.StartTime, Is.EqualTo(newStartTime));
    }
}