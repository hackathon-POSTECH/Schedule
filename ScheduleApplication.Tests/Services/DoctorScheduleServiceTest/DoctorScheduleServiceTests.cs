using FluentAssertions;
using Moq;
using ScheduleApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleApplication.Tests.Services.DoctorScheduleServiceTest;
[Collection(nameof(DoctorScheduleServiceCollection))]
public class DoctorScheduleServiceTests(DoctorScheduleServiceFixture fixture)
{


    [Fact(DisplayName = "Get list of doctor that is avaliable hours")]
    public async Task GetDoctorsAvaliableHours_WhenRequest_Valid_ShouldBeOk()
    {
        // Arrange
        fixture.Execute();

        var doctorSchedules = fixture.CreateDoctorSchedules(10);

        fixture.DoctorScheduleRepository.Setup(s => s.GetAllAsync()).ReturnsAsync(doctorSchedules);

        // Act
        var result = await fixture.DoctorScheduleService.GetDoctorsAvaliableHours();

        // Assert
        result.Success.Should().Be(true);
    }
}




