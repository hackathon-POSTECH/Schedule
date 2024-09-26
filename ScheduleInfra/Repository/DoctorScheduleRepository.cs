using Microsoft.EntityFrameworkCore;
using ScheduleDomain.Entities;
using ScheduleDomain.Interface;

namespace ScheduleInfra.Repository;

public class DoctorScheduleRepository(ScheduleContext context)
    : BaseRepository<DoctorSchedule>(context), IDoctorScheduleRepository
{
    public DoctorSchedule? GetById(Guid doctorScheduleId)
    {
        return _context.DoctorSchedules.FirstOrDefault(x => x.Id == doctorScheduleId);
    }

    public void DeleteById(Guid doctorScheduleId)
    {
        DoctorSchedule model = _context.DoctorSchedules.First(x => x.Id == doctorScheduleId);
        
        _context.DoctorSchedules.Remove(model);
    }

    public void CancelSchedule(Guid doctorScheduleId)
    {
        DoctorSchedule model = _context.DoctorSchedules.First(x => x.Id == doctorScheduleId);

        model.ExcludePatinent();

        _context.Update(model);
    }

    public List<DoctorSchedule> CreateDoctorSchedule(List<DoctorSchedule> doctorSchedules, Guid doctorId)
    {
        var list = new List<DoctorSchedule>();
        
        var schedules = _context.DoctorSchedules.Where(x => x.DoctorId == doctorId);
        
        foreach (var item in doctorSchedules)
        {
            if (schedules.Any(x => x.StartTime == item.StartTime && x.FinishTime == item.FinishTime))
                continue;
            
            DoctorSchedule model = new DoctorSchedule();

            model
                .SetDoctor(item.DoctorId)
                .SetFinishTime(item.FinishTime)
                .SetStartTime(item.StartTime)
                .SetDate(item.Date);
            
            
            _context.DoctorSchedules.Add(model);
            list.Add(model);
        }
        
        return list;
    }

    public async Task<DoctorSchedule?> GetByDoctorIdAsync(Guid doctorId)
    {
        var result = await _context.DoctorSchedules.FirstOrDefaultAsync(w => w.DoctorId == doctorId);

        return result;
    }
}