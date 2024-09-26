using Microsoft.EntityFrameworkCore;
using ScheduleDomain.Entities;
using ScheduleDomain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleInfra.Repository;

public class ScheduleRepository(ScheduleContext context)  : BaseRepository<Schedule>(context), IScheduleRepository
{
}

