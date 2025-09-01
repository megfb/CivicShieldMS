using CivicShieldMS.AuthService.Api.Application.Commands;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace CivicShieldMS.AuthService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase // Removed parentheses after class name
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly IMediator _mediator;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost("test")]
        public async Task<IActionResult> Test()
        {
            var user = new RegisterUserCommand
            {
                UserName = "userrr",
                Email = "userrr@user.com",
                Password = "Qqq.q12345"
            };
            await _mediator.Send(user); // Removed assignment to 'result' as Send returns void

            return Ok("okey");
        }
    }
}
