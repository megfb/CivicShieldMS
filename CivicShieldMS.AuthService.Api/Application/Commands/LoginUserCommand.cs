using CivicShieldMS.Shared.Common.Response;
using MediatR;

namespace CivicShieldMS.AuthService.Api.Application.Commands
{
    public class LoginUserCommand:IRequest<Shared.Common.Response.IResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
