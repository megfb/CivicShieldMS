using CivicShieldMS.Shared.EventBus.Abstractions;
using CivicShieldMS.Shared.EventBus.Events;
using Microsoft.AspNetCore.Mvc;

namespace CivicShieldMS.AlertService.Api.Controllers
{
    public class TestController : ControllerBase
    {
        private IEventBus _eventBus;
        public TestController(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        [HttpPost("test")]
        public async Task<IActionResult> Test()
        {
            var test = new TestIntegrationEvent()
            {
                Name = "Test Event",
            };

            await _eventBus.PublishAsync(test);

            return Ok("Gönderildi");
        }
    }
}
