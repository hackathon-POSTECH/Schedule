using FluentAssertions;
using Moq;
using ScheduleApplication.Data;
using ScheduleDomain.Entities;

namespace ScheduleApplication.Tests.Services.DoctorScheduleServiceTest;
[Collection(nameof(DoctorScheduleServiceCollection))]
public class DoctorScheduleServiceTests(DoctorScheduleServiceFixture fixture)
{
    [Fact(DisplayName = "Cria agendamento")]
    public async Task CreateSchedule_WhenRequest_Valid_ShouldBeOk()
    {
        // Arrange
        fixture.Execute();

        List<DoctorSchedule> doctorSchedules = fixture.CreateDoctorSchedules(1);

        var doctorId = doctorSchedules[0].Id;

        fixture.DoctorScheduleRepository.Setup(s => s.CreateDoctorSchedule(It.IsAny<List<DoctorSchedule>>(), doctorId)).Returns(doctorSchedules);

        // Act
        Result result = fixture.DoctorScheduleService.CreateSchedule(doctorId, DateTime.UtcNow, 8, 9);

        // Assert
        result.Should().NotBeNull();
    }


    [Fact(DisplayName = "Atualiza agendamento")]
    public async Task UpdateSchedule_WhenRequest_Valid_ShouldBeOk()
    {
        // Arrange
        fixture.Execute();

        var doctorSchedule = fixture.CreateDoctorSchedules(1).FirstOrDefault();

        fixture.DoctorScheduleRepository.Setup(s => s.GetById(It.IsAny<Guid>())).Returns(doctorSchedule);

        // Act
        Result result = fixture.DoctorScheduleService.UpdateSchedule(doctorSchedule.Id, Guid.NewGuid(), DateTime.UtcNow, 1, 1);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact(DisplayName = "Deleta agendamento")]
    public async Task DeleteSchedule_WhenRequest_Valid_ShouldBeOk()
    {
        // Arrange
        fixture.Execute();

        DoctorSchedule doctorSchedule = fixture.CreateDoctorSchedules(1).First();

        fixture.DoctorScheduleRepository.Setup(s => s.GetById(It.IsAny<Guid>())).Returns(doctorSchedule);

        // Act
        Result result = fixture.DoctorScheduleService.DeleteSchedule(doctorSchedule.Id);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact(DisplayName = "Cancela agendamento")]
    public async Task CancelSchedule_WhenRequest_Valid_ShouldBeOk()
    {
        // Arrange
        fixture.Execute();
            
        DoctorSchedule doctorSchedule = fixture.CreateDoctorSchedules(1).First();

        fixture.DoctorScheduleRepository.Setup(s => s.GetById(It.IsAny<Guid>())).Returns(doctorSchedule);

        // Act
        Result result = fixture.DoctorScheduleService.CancelSchedule(doctorSchedule.Id);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact(DisplayName = "Retorna uma lista de horários disponíveis")]
    public async Task GetDoctorsAvaliableHours_WhenRequest_Valid_ShouldBeOk()
    {
        // Arrange
        fixture.Execute();

        List<DoctorSchedule> doctorSchedules = fixture.CreateDoctorSchedules(1);

        fixture.DoctorScheduleRepository.Setup(s => s.GetAllHours(null)).ReturnsAsync(doctorSchedules);

        // Act
        Result result = await fixture.DoctorScheduleService.GetDoctorsAvaliableHours();

        // Assert
        result.Should().NotBeNull();
        result.Object.Should().BeEquivalentTo(doctorSchedules);
    }

    [Fact(DisplayName = "Retorna uma lista de horários disponíveis pelo id do médico")]
    public async Task GetDoctorsAvaliableHoursByDoctorId_WhenRequest_Valid_ShouldBeOk()
    {
        // Arrange
        fixture.Execute();

        List<DoctorSchedule> doctorSchedules = fixture.CreateDoctorSchedules(1);

        var doctorId = doctorSchedules.First().DoctorId;

        fixture.DoctorScheduleRepository.Setup(s => s.GetListByDoctorIdAsync(It.IsAny<Guid>())).Returns(doctorSchedules);

        // Act
        Result result = await fixture.DoctorScheduleService.GetDoctorsAvaliableHoursByDoctorId(doctorId);

        // Assert
        result.Should().NotBeNull();
    }
}




