using ScheduleDomain.Interface;
using ScheduleInfra.Repository;

namespace ScheduleApi.Configuration;

public static class DependencyInjectionConfiguration
{
    public static void AddDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IConsultRepository, ConsultRepository>();
    }
}

