using CivicShieldMS.Shared.EventBus.Abstractions;

namespace CivicShieldMS.Shared.EventBus.Events
{
    public class TestIntegrationEvent : IntegrationEvent
    {
        public string Name { get; set; }
    }
}
