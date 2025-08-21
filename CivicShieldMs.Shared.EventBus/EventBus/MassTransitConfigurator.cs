using System.Reflection;
using MassTransit;
using Microsoft.Extensions.Hosting;

namespace CivicShieldMS.Shared.EventBus.EventBus
{
    public static class MassTransitConfigurator
    {
        public static void Configure(this IBusRegistrationConfigurator configurator, IHostEnvironment environment, Assembly[] assemblies, Action<IRabbitMqBusFactoryConfigurator>? customConfig = null)
        {
            var formatter = new KebabCaseEndpointNameFormatter(environment.IsDevelopment() ? "local-" : "docker-");
            configurator.SetEndpointNameFormatter(formatter);
            configurator.SetKebabCaseEndpointNameFormatter();

            configurator.AddConsumers(assemblies);

            var rabbitMQHost = environment.IsDevelopment() ? "localhost" : "rabbitmq";

            configurator.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(rabbitMQHost, 5672, "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ConfigureEndpoints(context);
                customConfig?.Invoke(cfg);
            });
        }
    }
}
