using ScheduleDomain.Entities;
using ScheduleDomain.Interface;

namespace ScheduleInfra.Repository;

public class DoctorScheduleRepository : IDoctorScheduleRepository
{
    public DoctorSchedule GetById(Guid doctorScheduleId)
    {
        throw new NotImplementedException();
    }

    public void DeleteById(Guid doctorScheduleId)
    {
        throw new NotImplementedException();
    }

    public void CancelSchedule(Guid doctorScheduleId)
    {
        throw new NotImplementedException();
    }

    public List<DoctorSchedule> CreateDoctorSchedule(List<DoctorSchedule> doctorSchedules)
    {
        throw new NotImplementedException();
    }
}