using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ScheduleApplication.Data;
using ScheduleApplication.Services.Interface;
using ScheduleDomain.Entities;

namespace ScheduleApi.Controllers
{
    [Route("[controller]")]
    public class DoctorScheduleController(IDoctorScheduleService doctorScheduleService) : Controller
    {
        [HttpGet("DoctorAvaliable")]
        public Result GetDoctorsAvaliableHours()
        {
            try
            {
                var value = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (value != null)
                {
                    Guid userId = Guid.Parse(value);
                
                    Result list = doctorScheduleService.GetDoctorsAvaliableHours(userId);

                    if (list.Object != null)
                        return Result.ObjectResult(list.Object, "Succeso ao buscar os horários do médico");
                }

                return Result.FailResult("Não foi possível encontrar os horários do médico");
            }
            catch (Exception e)
            {
                return Result.FailResult(e.Message);
            }
        }
        
        [HttpGet("CreateDoctorSchedule")]
        public Result CreateDoctorSchedule(Guid doctorId, DateTime date, int start, int end)
        {
            try
            {
                if (end < start)
                    return Result.FailResult("Não é possível inserir um horário de término inferior ao de início");

                if (date < DateTime.Now)
                    return Result.FailResult("Não é possível criar um horário no passado");
                
                return doctorScheduleService.CreateSchedule(doctorId, date, start, end);
            }
            catch (Exception e)
            {
                return Result.FailResult(e.Message);
            }
        }

        [HttpGet("DoctorAvaliable/{doctorId:guid}")]
        public async Task<Result>GetDoctorsAvaliableHoursByDoctorId([FromRoute] Guid doctorId)
        {
            return await doctorScheduleService.GetDoctorsAvaliableHoursByDoctorId(doctorId);
        }
    }
}
