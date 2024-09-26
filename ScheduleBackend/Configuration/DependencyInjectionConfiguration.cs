using ScheduleDomain.Interface;
using ScheduleInfra.Repository;

namespace ScheduleApi.Configuration;

public static class DependencyInjectionConfiguration
{
    public static void AddDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IDoctorScheduleRepository, DoctorScheduleRepository>();
        services.AddScoped<IScheduleRepository, ScheduleRepository>();


        services.AddScoped<IScheduleRepository, ScheduleRepository>();
        services.AddScoped<IConsultRepository, ConsultRepository>();
    }
}

