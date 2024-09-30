using MassTransit;
using ScheduleApplication.Data;
using ScheduleApplication.Model.Request;
using ScheduleApplication.Services.Interface;
using ScheduleDomain.Entities;
using ScheduleDomain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleApplication.Services;

public class ScheduleService(IScheduleRepository scheduleRepository, IDoctorScheduleRepository doctorScheduleRepository, IRabbitMqService rabbitMqService) : IScheduleService
{
    public async Task<Result> CreateSchedule(CreateScheduleRequest request)
    {
        var doctorSchedule = await doctorScheduleRepository.GetByDoctorScheduleIdAsync(request.DoctorScheduleId);

        if (doctorSchedule == null) return Result.FailResult("Horário indiponível!");

        if (doctorSchedule.PatientId != null) return Result.FailResult("Esse horário já esta reservado!");

        doctorSchedule.SetPatient(request.PatientId);

        await doctorScheduleRepository.UpdateAsync(doctorSchedule);

        var model = new Schedule();

        model
            .SetDoctorSchedule(request.DoctorScheduleId)
            .SetStatus(request.Status)
            .SetType(request.Type);

        await scheduleRepository.AddAsync(model);

        var message = new AppointmentNotificationMessageRequest(doctorSchedule.DoctorId, doctorSchedule.PatientId ?? new(), doctorSchedule.Date, doctorSchedule.StartTime);

        var requestRabbit = new RabbitMqPublishRequest<AppointmentNotificationMessageRequest>()
        {
            ExchangeName = "exchange_notification",
            RoutingKey = "notification_queue",
            MessageType = new List<string>() { "urn:message:Notification.DOMAIN.Messages:AppointmentNotificationMessage" },
            Message = message
        };

        rabbitMqService.Publish(requestRabbit);

        return Result.SuccessResult("Agendamento criado com sucesso.");
    }
}

