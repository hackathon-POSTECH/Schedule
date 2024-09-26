using ScheduleApplication.Services;
using ScheduleApplication.Services.Interface;
using ScheduleDomain.Interface;
using ScheduleInfra.Repository;

namespace ScheduleApi.Configuration;

public static class DependencyInjectionConfiguration
{
    public static void AddDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IDoctorScheduleService, DoctorScheduleService>();
        services.AddScoped<IScheduleService, ScheduleService>();
        services.AddScoped<IRabbitMqService, RabbitMqService>();


        services.AddScoped<IDoctorScheduleRepository, DoctorScheduleRepository>();
        services.AddScoped<IScheduleRepository, ScheduleRepository>();
        services.AddScoped<IConsultRepository, ConsultRepository>();
    }
}

