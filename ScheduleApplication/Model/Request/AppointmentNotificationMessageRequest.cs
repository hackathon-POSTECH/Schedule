using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ScheduleApplication.Model.Request;

public class AppointmentNotificationMessageRequest
{
    [JsonPropertyName("doctor")]
    public Guid Doctor { get; set; }

    [JsonPropertyName("patient")]
    public Guid Patient { get; set; }

    [JsonPropertyName("appointmentDate")]
    public DateTime AppointmentDate { get; set; }

    [JsonPropertyName("appointmentTime")]
    public TimeSpan AppointmentTime { get; set; }

    public AppointmentNotificationMessageRequest()
    {
    }

    public AppointmentNotificationMessageRequest(Guid doctor, Guid patient, DateTime appointmentDate, TimeSpan appointmentTime)
    {
        Doctor = doctor;
        Patient = patient;
        AppointmentDate = appointmentDate;
        AppointmentTime = appointmentTime;
    }
}
