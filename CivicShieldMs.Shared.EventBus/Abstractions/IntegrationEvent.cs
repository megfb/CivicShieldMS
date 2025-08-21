namespace CivicShieldMS.Shared.EventBus.Abstractions
{
    public abstract class IntegrationEvent
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
