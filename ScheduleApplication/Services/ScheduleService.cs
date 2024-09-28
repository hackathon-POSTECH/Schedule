using ScheduleApplication.Data;
using ScheduleApplication.Model.Request;
using ScheduleApplication.Services.Interface;
using ScheduleDomain.Entities;
using ScheduleDomain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleApplication.Services;

public class ScheduleService(IScheduleRepository scheduleRepository) : IScheduleService
{
    public async Task<Result> CreateSchedule(CreateScheduleRequest request)
    {
        var model = new Schedule();

        model
            .SetDoctorSchedule(request.DoctorScheduleId)
            .SetStatus(request.Status)
            .SetType(request.Type);

        await scheduleRepository.AddAsync(model);

        return Result.SuccessResult("Schedule created with success.");
    }
}

