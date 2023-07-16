using APIIntegration.Infrastructure.Context;
using APIIntegration.Infrastructure.IntegrationEvents;
using APIIntegration.Infrastructure.Repositories;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace APIIntegration.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq();
            });

            services.AddSingleton<DapperContext>();
            services.AddScoped<IApiIntegrationEvent, ApiIntegrationEvent>();
            services.AddScoped<ITaskSampleRepository, TaskSampleRepository>();

            return services;
        }
    }
}
