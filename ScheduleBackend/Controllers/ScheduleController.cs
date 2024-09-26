using Microsoft.AspNetCore.Mvc;
using ScheduleApplication.Data;
using ScheduleApplication.Model.Request;
using ScheduleApplication.Services.Interface;

namespace ScheduleApi.Controllers;

[Route("[controller]")]
public class ScheduleController(IScheduleService scheduleService) : Controller
{
    [HttpPost]
    public async Task<Result> Post([FromBody] CreateScheduleRequest request)
    {
        return await scheduleService.CreateSchedule(request);
    }
}

