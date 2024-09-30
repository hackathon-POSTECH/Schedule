using FluentAssertions;
using MassTransit;
using ScheduleApplication.Model.Request;
using ScheduleApplication.Tests.Services.ScheduleServiceTest;
using ScheduleDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleApplication.Tests.Services.ScheduleServiceTests;

[Collection(nameof(ScheduleServiceCollection))]
public class ScheduleServiceTests(ScheduleServiceFixture fixture)
{
    [Fact(DisplayName = "Retorna uma lista de horários disponíveis pelo id do médico")]
    public async Task _WhenRequest_Valid_ShouldBeOk()
    {
        // Arrange
        fixture.Execute();

        DoctorSchedule doctorSchedule = fixture.CreateDoctorSchedulesWithPacientIdNull(1).First();

        fixture.DoctorScheduleRepository.Setup(s => s.GetByDoctorScheduleIdAsync(doctorSchedule.Id));

        var request = new CreateScheduleRequest()
        {
            DoctorScheduleId = doctorSchedule.Id,
            PatientId = Guid.NewGuid(),
        };

        // Act
        var result = await fixture.ScheduleService.CreateSchedule(request);

        // Assert
        result.Should().NotBeNull();
    }
}

