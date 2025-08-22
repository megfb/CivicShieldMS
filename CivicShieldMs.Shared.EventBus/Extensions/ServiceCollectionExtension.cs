using System.Reflection;
using CivicShieldMS.Shared.EventBus.Abstractions;
using CivicShieldMS.Shared.EventBus.EventBus;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CivicShieldMS.Shared.EventBus.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddSharedEventBus(this IServiceCollection services, Assembly[] consumerAssemblies, IHostEnvironment environment)
        {
            services.AddScoped<IEventBus, EventBusRabbitMQ>();

            services.AddMassTransit(config =>
            {
                config.ConfigureEventBus(environment, consumerAssemblies);
            });

            return services;
        }
    }
}
