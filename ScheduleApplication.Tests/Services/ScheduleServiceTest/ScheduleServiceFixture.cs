using Bogus;
using Microsoft.Extensions.Logging;
using Moq;
using ScheduleApplication.Services;
using ScheduleApplication.Services.Interface;
using ScheduleApplication.Tests.Services.DoctorScheduleServiceTest;
using ScheduleDomain.Entities;
using ScheduleDomain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleApplication.Tests.Services.ScheduleServiceTest;

[CollectionDefinition(nameof(ScheduleServiceCollection))]
public class ScheduleServiceCollection : ICollectionFixture<ScheduleServiceFixture>;

public class ScheduleServiceFixture
{
    public const string CultureFaker = "pt_BR";

    public ScheduleService ScheduleService;

    public Mock<IScheduleRepository> ScheduleRepository;
    public Mock<IDoctorScheduleRepository> DoctorScheduleRepository;
    public Mock<IRabbitMqService> RabbitMqService;
    public Mock<ILogger<ScheduleService>> Logger;


    public void Execute()
    {
        ScheduleRepository = new Mock<IScheduleRepository>();
        DoctorScheduleRepository = new Mock<IDoctorScheduleRepository>();
        RabbitMqService = new Mock<IRabbitMqService>();
        Logger = new Mock<ILogger<ScheduleService>>();

        ScheduleService = new ScheduleService(ScheduleRepository.Object, DoctorScheduleRepository.Object, RabbitMqService.Object);
    }

    public List<DoctorSchedule> CreateDoctorSchedules(int quantity)
    {
        return new Faker<DoctorSchedule>(CultureFaker).CustomInstantiator(f =>
        {
            DoctorSchedule model = new DoctorSchedule();

            model.SetPatient(Guid.NewGuid())
                .SetDoctor(Guid.NewGuid())
                .SetStartTime(TimeSpan.FromHours(1))
                .SetFinishTime(TimeSpan.FromHours(2))
                .SetDate(DateTime.Today);

            return model;
        }).Generate(quantity);
    }
}

