using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScheduleApplication.Data;
using ScheduleApplication.Services.Interface;

namespace ScheduleApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class DoctorScheduleController(IDoctorScheduleService doctorScheduleService) : Controller
    {
        [HttpGet("DoctorAvaliable")]
        public async Task<Result> GetDoctorsAvaliableHours()
        {
            try
            {
                Result list = await doctorScheduleService.GetDoctorsAvaliableHours();

                if (list.Object != null)
                    return Result.ObjectResult(list.Object, "Succeso ao buscar os horários dos médicos");
             
                return Result.FailResult("Não foi possível encontrar os horários dos médicos");
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

                if (date.Date < DateTime.Now.Date)
                    return Result.FailResult("Não é possível criar um horário no passado");
                
                return doctorScheduleService.CreateSchedule(doctorId, date, start, end);
            }
            catch (Exception e)
            {
                return Result.FailResult(e.Message);
            }
        }

        [HttpPost("UpdateDoctorSchedule")]
        public Result UpdateDoctorSchedule(Guid doctorScheduleId, Guid? patientId, DateTime date, int start, int end)
        {
            try
            {
                if (end < start)
                    return Result.FailResult("Não é possível editar um horário de término inferior ao de início");

                if (date.Date < DateTime.Now.Date)
                    return Result.FailResult("Não é possível editar um horário no passado");
                
                return doctorScheduleService.UpdateSchedule(doctorScheduleId, patientId, date, start, end);
            }
            catch (Exception e)
            {
                return Result.FailResult(e.Message);
            }
        }
        
        [HttpPost("CancelSchedule")]
        public Result CancelSchedule(Guid doctorScheduleId)
        {
            try
            {
                return doctorScheduleService.CancelSchedule(doctorScheduleId);
            }
            catch (Exception e)
            {
                return Result.FailResult(e.Message);
            }
        }
        
        [HttpPost("DeleteSchedule")]
        public Result DeleteSchedule(Guid doctorScheduleId)
        {
            try
            {
                return doctorScheduleService.DeleteSchedule(doctorScheduleId);
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
