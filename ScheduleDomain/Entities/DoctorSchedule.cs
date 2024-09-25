namespace ScheduleDomain.Entities;

public class DoctorSchedule : Entity
{
    public DateTime Date { get; set; }
    public Guid DoctorId { get; set; }
    public Guid? PatientId { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan FinishTime { get; set; }

    public static DoctorSchedule Create(Guid doctorId, DateTime date, TimeSpan startTime, TimeSpan finishTime)
    {
        DoctorSchedule model = new ();
        
        model.DoctorId = doctorId;
        model.Date = date;
        model.StartTime = startTime;
        model.FinishTime = finishTime;

        return model;
    }

    public void SetPatient(Guid pacientId)
    {
        PatientId = pacientId;
    }

    public void ExcludePatient()
    {
        PatientId = null;
    }
}