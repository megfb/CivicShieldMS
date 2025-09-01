using CivicShieldMS.AuthService.Api.Application.Commands;
using CivicShieldMS.AuthService.Api.Domain.Entities;
using CivicShieldMS.AuthService.Api.Dtos;
using CivicShieldMS.AuthService.Api.Infrastructure.Security;
using CivicShieldMS.Shared.Common.Response;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CivicShieldMS.AuthService.Api.Application.CommandHandlers
{
    public class LoginUserCommandHandler(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,ITokenService tokenService) :
        IRequestHandler<LoginUserCommand, Shared.Common.Response.IResult>
    {
        private readonly ITokenService _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        private readonly SignInManager<ApplicationUser> _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        private readonly UserManager<ApplicationUser> _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        public async Task<Shared.Common.Response.IResult> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                return new ErrorResult { Success = false, Message = "User not found" };

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!result.Succeeded)
                return new ErrorResult { Success = false, Message = "Invalid credentials" };
            var roles = await _userManager.GetRolesAsync(user);
            var token = _tokenService.CreateToken(user,roles);

            return new SuccessDataResult<ApplicationUserDto>("Login is succesfully",new ApplicationUserDto
            {
                Id = user.Id,
                Email = user.Email!,
                UserName = user.UserName!,
                Roles = roles.ToList(),
                Token = token
            });
        }
    }
}
