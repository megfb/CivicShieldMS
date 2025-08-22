using CivicShieldMS.Shared.EventBus.Abstractions;
using MassTransit;

namespace CivicShieldMS.Shared.EventBus.EventBus
{

    public class EventBusRabbitMQ(IPublishEndpoint publishEndPoint) : IEventBus
    {
        private readonly IPublishEndpoint _publishEndPoint = publishEndPoint ?? throw new ArgumentNullException(nameof(publishEndPoint));

        public async Task PublishAsync<TEvent>(TEvent @event, string exchangeName, string routingKey)
        {
            await _publishEndPoint.Publish(@event!, ctx =>
            {
                ctx.SetRoutingKey(routingKey);
                ctx.DestinationAddress = new Uri($"exchange:{exchangeName}");
            });
        }
    }


}
