using Microsoft.EntityFrameworkCore;
using ScheduleDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleInfra;

public class ScheduleContext : DbContext
{
    public ScheduleContext(DbContextOptions<ScheduleContext> options) : base(options) { }

    public DbSet<Consult> Consults { get; set; }
    public DbSet<DoctorSchedule> DoctorSchedules { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
}

