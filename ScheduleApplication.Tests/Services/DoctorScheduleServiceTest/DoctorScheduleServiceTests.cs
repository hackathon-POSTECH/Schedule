using FluentAssertions;
using Moq;
using ScheduleApplication.Data;
using ScheduleDomain.Entities;

namespace ScheduleApplication.Tests.Services.DoctorScheduleServiceTest;
[Collection(nameof(DoctorScheduleServiceCollection))]
public class DoctorScheduleServiceTests(DoctorScheduleServiceFixture fixture)
{


    [Fact(DisplayName = "Retorna uma lista de horários disponíveis")]
    public async Task GetDoctorsAvaliableHours_WhenRequest_Valid_ShouldBeOk()
    {
        // Arrange
        fixture.Execute();

        List<DoctorSchedule> doctorSchedules = fixture.CreateDoctorSchedules(1);

        fixture.DoctorScheduleRepository.Setup(s => s.GetAllAsync()).ReturnsAsync(doctorSchedules);

        // Act
        Result result = await fixture.DoctorScheduleService.GetDoctorsAvaliableHours();

        // Assert
        result.Should().NotBeNull();
        result.Object.Should().BeEquivalentTo(doctorSchedules);
    }
}




