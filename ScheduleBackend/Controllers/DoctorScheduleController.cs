using Microsoft.AspNetCore.Mvc;
using ScheduleApplication.Data;
using ScheduleApplication.Services.Interface;

namespace ScheduleApi.Controllers
{
    [Route("[controller]")]
    public class DoctorScheduleController(IDoctorScheduleService doctorScheduleService) : Controller
    {
        [HttpGet("DoctorAvaliable")]
        public async Task<Result> GetDoctorsAvaliableHours()
        {
            return await doctorScheduleService.GetDoctorsAvaliableHours();
        }

        [HttpGet("DoctorAvaliable/{doctorId:guid}")]
        public async Task<Result>GetDoctorsAvaliableHoursByDoctorId([FromRoute] Guid doctorId)
        {
            return await doctorScheduleService.GetDoctorsAvaliableHoursByDoctorId(doctorId);
        }
    }
}
