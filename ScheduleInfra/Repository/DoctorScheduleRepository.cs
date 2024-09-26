using Microsoft.EntityFrameworkCore;
using ScheduleDomain.Entities;
using ScheduleDomain.Interface;

namespace ScheduleInfra.Repository;

public class DoctorScheduleRepository(ScheduleContext context) : BaseRepository<DoctorSchedule>(context), IDoctorScheduleRepository
{
    public List<DoctorSchedule> CreateDoctorSchedule(List<DoctorSchedule> doctorSchedules)
    {
        throw new NotImplementedException();
    }
    public async Task<DoctorSchedule?> GetByDoctorIdAsync(Guid doctorId)
    {
        var result = await _context.DoctorSchedules.FirstOrDefaultAsync(w => w.DoctorId == doctorId);

        return result;
    }
}