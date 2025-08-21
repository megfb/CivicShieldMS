using CivicShieldMS.IncidentService.Api.Application.Commands;
using CivicShieldMS.IncidentService.Api.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CivicShieldMS.IncidentService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [HttpPost("CreateIncident")]
        public async Task<IActionResult> CreateIncident(CreateIncidentCommand incident)
        {
            Console.WriteLine("cicd başarılı");
            return Ok(await _mediator.Send(incident));
        }
        [HttpDelete("DeletIncident")]
        public async Task<IActionResult> DeleteIncident(string id)
        {
            return Ok(await _mediator.Send(new DeleteIncidentCommand { Id = id }));
        }
        [HttpGet("GetIncidents")]
        public async Task<IActionResult> GetIncidents()
        {
            return Ok(await _mediator.Send(new GetAllIncidentsQuery()));
        }
        [HttpGet("GetIncidentById/{id}")]
        public async Task<IActionResult> GetIncidentById(string id)
        {
            return Ok(await _mediator.Send(new GetIncidentsByIdQuery { Id = id }));
        }
    }
}
