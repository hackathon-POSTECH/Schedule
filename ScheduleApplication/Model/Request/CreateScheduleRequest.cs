using ScheduleDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleApplication.Model.Request;

public class CreateScheduleRequest
{
    public Guid DoctorScheduleId { get; set; }
    public Guid PatientId { get; set; }
    public EStatusSchedule Status { get; set; }
    public ETypeSchedule Type { get; set; }
}

