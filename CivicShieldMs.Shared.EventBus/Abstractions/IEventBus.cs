namespace CivicShieldMS.Shared.EventBus.Abstractions
{
    public interface IEventBus
    {
        Task PublishAsync<TEvent>(TEvent @event) where TEvent : IntegrationEvent;
        //void Subscribe<T, TH>(string exchange, string queueName, string routingKey)
        //    where T : IntegrationEvent
        //    where TH : IIntegrationEventHandler<T>;
    }
}
