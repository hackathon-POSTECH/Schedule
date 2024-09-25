using ScheduleApplication.Data;

namespace ScheduleApplication.Services.Interface
{
    public interface IDoctorScheduleService
    {
        Result CreateSchedule(Guid doctorId, DateTime date, int startDate, int endDate);
    }
}
