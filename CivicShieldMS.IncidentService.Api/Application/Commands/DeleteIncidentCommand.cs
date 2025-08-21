using MediatR;

namespace CivicShieldMS.IncidentService.Api.Application.Commands
{
    public class DeleteIncidentCommand : IRequest<Shared.Common.Response.IResult>
    {
        public string Id { get; set; }
    }
}
