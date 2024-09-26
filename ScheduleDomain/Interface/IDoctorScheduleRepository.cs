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
    void DeleteById(Guid doctorScheduleId);
    void CancelSchedule(Guid doctorScheduleId);
    List<DoctorSchedule> CreateDoctorSchedule(List<DoctorSchedule> doctorSchedules, Guid doctorId);

    Task<DoctorSchedule?> GetByDoctorIdAsync(Guid doctorId);
}

