using CivicShieldMS.Shared.EventBus.Events;
using MassTransit;

namespace CivicShieldMS.AuthService.Api
{
    public class TestIntegrationEventHandler : IConsumer<TestIntegrationEvent>
    {
        public Task Consume(ConsumeContext<TestIntegrationEvent> context)
        {

            var message = context.Message;
            Console.WriteLine($"📨 Yeni olay: {message.Name}");
            return Task.CompletedTask;
        }

    }
}
