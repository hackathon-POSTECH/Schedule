using ScheduleApplication.Data;

namespace ScheduleApplication.Services.Interface
{
    public interface IDoctorScheduleService
    {
        Result CreateSchedule(Guid doctorId, DateTime date, int startDate, int endDate);
        Result UpdateSchedule(Guid doctorScheduleId, Guid doctorId, DateTime date, int startDate, int endDate);
        Result DeleteSchedule(Guid doctorScheduleId);
        Result CancelSchedule(Guid doctorScheduleId);
    }
}
