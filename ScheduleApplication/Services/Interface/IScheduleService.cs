using ScheduleApplication.Data;
using ScheduleApplication.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleApplication.Services.Interface;

public interface IScheduleService
{
    Task<Result> CreateSchedule(CreateScheduleRequest request);
}

