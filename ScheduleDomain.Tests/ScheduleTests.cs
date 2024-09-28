using ScheduleDomain.Entities;
using ScheduleDomain.Enums;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace ScheduleDomain.Tests;

public class ScheduleTests
{
    [Fact]
    public void SetDoctorSchedule_ShouldUpdateDoctorScheduleId()
    {
        // Arrange
        var schedule = new Schedule();
        var doctorScheduleId = Guid.NewGuid();

        // Act
        schedule.SetDoctorSchedule(doctorScheduleId);

        // Assert
        Assert.That(schedule.DoctorScheduleId, Is.EqualTo(doctorScheduleId));
    }

    [Fact]
    public void SetStatus_ShouldUpdateStatus()
    {
        // Arrange
        var schedule = new Schedule();
        var status = EStatusSchedule.InProgress;

        // Act
        schedule.SetStatus(status);

        // Assert
        Assert.That(schedule.Status, Is.EqualTo(status));
    }

    [Fact]
    public void SetType_ShouldUpdateType()
    {
        // Arrange
        var schedule = new Schedule();
        var type = ETypeSchedule.GeneralClinic;

        // Act
        schedule.SetType(type);

        // Assert
        Assert.That(schedule.Type, Is.EqualTo(type));
    }
    
    [Fact]
    public void SetStatus_ShouldThrowException_WhenStatusIsCancelled()
    {
        // Arrange
        var schedule = new Schedule();
        schedule.SetStatus(EStatusSchedule.Cancel);

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => schedule.SetStatus(EStatusSchedule.Finished));
        Assert.That(exception.Message, Is.EqualTo("Status já está cancelado e não pode ser alterado"));
    }
}