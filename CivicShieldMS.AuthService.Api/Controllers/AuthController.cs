using CivicShieldMS.AuthService.Api.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CivicShieldMS.AuthService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IMediator mediatr) : ControllerBase
    {
        private readonly IMediator _mediator = mediatr ?? throw new ArgumentNullException(nameof(mediatr));

        [Authorize]
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUserCommand registerUserCommand)
        {
            return Ok(await _mediator.Send(registerUserCommand));
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserCommand loginUserCommand)
        {
            return Ok(await _mediator.Send(loginUserCommand));
        }
    }
}
