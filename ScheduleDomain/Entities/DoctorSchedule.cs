namespace ScheduleDomain.Entities;

public class DoctorSchedule : Entity
{
    public DoctorSchedule() { }
    public DateTime Date { get; private set; }
    public Guid DoctorId { get; private set; }
    public Guid? PatientId { get; private set; }
    public TimeSpan StartTime { get; private set; }
    public TimeSpan FinishTime { get; private set; }

    public static DoctorSchedule Create(Guid doctorId, DateTime date, TimeSpan startTime, TimeSpan finishTime)
    {
        DoctorSchedule model = new ();
        
        model.DoctorId = doctorId;
        model.Date = date;
        model.StartTime = startTime;
        model.FinishTime = finishTime;

        return model;
    }

    public DoctorSchedule SetDoctor(Guid doctorId)
    {
        DoctorId = doctorId;
        return this;
    }
    
    public DoctorSchedule SetPatient(Guid? pacientId)
    {
        PatientId = pacientId;
        return this;
    }
    
    public DoctorSchedule SetFinishTime(TimeSpan finishTime)
    {
        FinishTime = finishTime;
        return this;
    }
    
    public DoctorSchedule SetStartTime(TimeSpan startTime)
    {
        StartTime = startTime;
        return this;
    }
    
    public DoctorSchedule SetDate(DateTime date)
    {
        if (date.Date < DateTime.Now.Date)
            throw new ArgumentException("Horário não pode estar no passado!");
        
        Date = date;
        return this;
    }

    public DoctorSchedule Delete()
    {
        DeletedAt = DateTime.Now.ToUniversalTime();
        return this;
    }
    
    public DoctorSchedule ExcludePatient()
    {
        PatientId = null;
        return this;
    }
}