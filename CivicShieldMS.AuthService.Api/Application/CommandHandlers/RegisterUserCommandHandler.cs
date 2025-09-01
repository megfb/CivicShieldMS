using CivicShieldMS.AuthService.Api.Application.Commands;
using CivicShieldMS.AuthService.Api.Domain.Entities;
using CivicShieldMS.AuthService.Api.Domain.Repositories.Abstractions;
using CivicShieldMS.Shared.Common.Domain;
using CivicShieldMS.Shared.Common.Response;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CivicShieldMS.AuthService.Api.Application.CommandHandlers
{
    public class RegisterUserCommandHandler(IAuthRepository authRepository, UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationRole> roleManager) : IRequestHandler<RegisterUserCommand, Shared.Common.Response.IResult>
    {

        private readonly UserManager<ApplicationUser> _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        private readonly RoleManager<ApplicationRole> _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
        private readonly IAuthRepository _authRepository = authRepository ?? throw new ArgumentNullException(nameof(authRepository));

        async Task<Shared.Common.Response.IResult> IRequestHandler<RegisterUserCommand, Shared.Common.Response.IResult>.Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var User = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = request.UserName,
                Email = request.Email,
            };

            var result = await _authRepository.CreateAsync(User, request.Password);
            if (!result.Succeeded)
            {
                var errorMessage = string.Join("; ", result.Errors.Select(e => e.Description));
                return new ErrorResult { Message = errorMessage, Success = false };
            }
            string defaultRole = "User";
            if (!await _roleManager.RoleExistsAsync(defaultRole))
            {
                await _roleManager.CreateAsync(new ApplicationRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "User",
                    NormalizedName = "USER"
                });
            }
            await _userManager.AddToRoleAsync(User, defaultRole);

            return new Result(true, "User registered successfully", 200);
        }
    }

}
