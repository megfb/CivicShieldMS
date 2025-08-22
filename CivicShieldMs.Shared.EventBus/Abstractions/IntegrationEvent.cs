namespace CivicShieldMS.Shared.EventBus.Abstractions
{
    public abstract class IntegrationEvent:IIntegrationEvent
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public interface IIntegrationEvent
    {

    }
}
