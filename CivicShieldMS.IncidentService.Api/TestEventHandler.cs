using CivicShieldMS.Shared.EventBus.Events;
using MassTransit;

namespace CivicShieldMS.IncidentService.Api
{
    public class TestEventHandler : IConsumer<TestIntegrationEvent>
    {
        public Task Consume(ConsumeContext<TestIntegrationEvent> context)
        {

            var message = context.Message;
            Console.WriteLine($"📨 Yeni olay: {message.Name}");
            return Task.CompletedTask;
        }

    }
}
