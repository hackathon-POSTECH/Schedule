using ScheduleDomain.Enums;

namespace ScheduleDomain.Entities;

public class Schedule : Entity
{
    public Guid DoctorScheduleId { get; set; }
    public EStatusSchedule Status { get; set; }
    public ETypeSchedule Type { get; set; }
}

