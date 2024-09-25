using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleDomain.Entities;

namespace ScheduleDomain.Interface;

public interface IDoctorScheduleRepository
{
    List<DoctorSchedule> CreateDoctorSchedule(List<DoctorSchedule> doctorSchedules);
}

