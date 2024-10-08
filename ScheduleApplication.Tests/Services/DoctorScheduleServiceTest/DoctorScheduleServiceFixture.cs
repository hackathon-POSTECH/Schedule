﻿using Bogus;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using Moq;
using ScheduleApplication.Services;
using ScheduleDomain.Entities;
using ScheduleDomain.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleApplication.Tests.Services.DoctorScheduleServiceTest;

[CollectionDefinition(nameof(DoctorScheduleServiceCollection))]
public class DoctorScheduleServiceCollection : ICollectionFixture<DoctorScheduleServiceFixture>;

public class DoctorScheduleServiceFixture
{
    public const string CultureFaker = "pt_BR";

    public DoctorScheduleService DoctorScheduleService;

    public Mock<IDoctorScheduleRepository> DoctorScheduleRepository;
    public Mock<ILogger<DoctorScheduleService>> Logger;


    public void Execute()
    {
        DoctorScheduleRepository = new Mock<IDoctorScheduleRepository>();
        Logger = new Mock<ILogger<DoctorScheduleService>>();

        DoctorScheduleService = new DoctorScheduleService(DoctorScheduleRepository.Object, Logger.Object);
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