namespace ScheduleDomain.Entities;

public class DoctorSchedule : Entity
{
    public DateTime Date { get; set; }
    public Guid DoctorId { get; set; }
    public Guid? PacientId { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan FinishTime { get; set; }
}