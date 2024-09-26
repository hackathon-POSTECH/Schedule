using ScheduleApplication.Data;
using System.Threading.Tasks;

namespace ScheduleApplication.Services.Interface
{
    public interface IDoctorScheduleService
    {
        Result CreateSchedule(Guid doctorId, DateTime date, int startDate, int endDate);
        Task<Result> GetDoctorsAvaliableHours();
        Task<Result> GetDoctorsAvaliableHoursByDoctorId(Guid doctorId);
    }
}
