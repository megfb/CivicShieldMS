using CivicShieldMS.Shared.Common.Response;
using MediatR;

namespace CivicShieldMS.AuthService.Api.Application.Commands
{
    public class RegisterUserCommand:IRequest<Shared.Common.Response.IResult>
    {
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
