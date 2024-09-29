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

    public void CancelSchedule(Guid doctorScheduleId)
    {
        DoctorSchedule model = _context.DoctorSchedules.First(x => x.Id == doctorScheduleId);

        model.ExcludePatinent();

        _context.Update(model);
        _context.SaveChanges();
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
        _context.SaveChanges();
        return list;
    }

    public async Task<DoctorSchedule?> GetByDoctorScheduleIdAsync(Guid doctorScheduleId)
    {
        var result = await _context.DoctorSchedules.FirstOrDefaultAsync(w => w.Id == doctorScheduleId);

        return result;
    }
    
    public IEnumerable<DoctorSchedule> GetListByDoctorIdAsync(Guid doctorId)
    {
        try
        {
            var result = _context.DoctorSchedules.Where(w => w.DoctorId == doctorId && w.PatientId == null);

            return result;
        }
        catch (Exception)
        {
            return Enumerable.Empty<DoctorSchedule>();
        }
    }
    
    public async Task<List<DoctorSchedule>> GetAllHours(Guid? doctorId = null)
    {
        try
        {
            var query = _context.DoctorSchedules.AsQueryable();

            query = query.Where(x => x.Date >= DateTime.Now.Date.ToUniversalTime() && x.PatientId == null && x.DeletedAt == null);

            if (doctorId.HasValue)
            {
                query = query.Where(x => x.DoctorId == doctorId.Value);
            }

            return await query.ToListAsync().ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            return Enumerable.Empty<DoctorSchedule>().ToList();
        }
    }

}