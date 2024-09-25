using Microsoft.EntityFrameworkCore;
using ScheduleDomain.Entities;

namespace ScheduleInfra;

public class ScheduleContext : DbContext
{
    public ScheduleContext(DbContextOptions<ScheduleContext> options) : base(options) { }

    public DbSet<Consult> Consults { get; set; }
    public DbSet<DoctorSchedule> DoctorSchedules { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
}

