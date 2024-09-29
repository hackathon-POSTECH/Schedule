using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleDomain.Entities;

namespace ScheduleDomain.Interface;

public interface IDoctorScheduleRepository : IBaseRepository<DoctorSchedule>
{
    DoctorSchedule? GetById(Guid doctorScheduleId);
    void CancelSchedule(Guid doctorScheduleId);
    List<DoctorSchedule> CreateDoctorSchedule(List<DoctorSchedule> doctorSchedules, Guid doctorId);
    Task<DoctorSchedule?> GetByDoctorScheduleIdAsync(Guid doctorScheduleId);
    IEnumerable<DoctorSchedule> GetListByDoctorIdAsync(Guid doctorId);
    Task<List<DoctorSchedule>> GetAllHours(Guid? doctorId = null);
}

