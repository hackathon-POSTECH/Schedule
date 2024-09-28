using ScheduleDomain.Enums;

namespace ScheduleDomain.Entities;

public class Schedule : Entity
{
    public Schedule() { }
    public Guid DoctorScheduleId { get; private set; }
    public EStatusSchedule Status { get; private set; }
    public ETypeSchedule Type { get; private set; }

    public Schedule SetDoctorSchedule(Guid docthorScheduleId)
    {
        DoctorScheduleId = docthorScheduleId;
        return this;
    }

    public Schedule SetStatus(EStatusSchedule status)
    {
        if (Status == EStatusSchedule.Cancel)
            throw new ArgumentException("Status já está cancelado e não pode ser alterado");
        
        Status = status;
        return this;
    }

    public Schedule SetType(ETypeSchedule type)
    {
        Type = type;
        return this;
    }
}

