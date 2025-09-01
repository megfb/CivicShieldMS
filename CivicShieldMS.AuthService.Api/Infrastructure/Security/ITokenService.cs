using CivicShieldMS.AuthService.Api.Domain.Entities;

namespace CivicShieldMS.AuthService.Api.Infrastructure.Security
{
    public interface ITokenService
    {
        public string CreateToken(ApplicationUser user,IEnumerable<string> Roles);
    }
}
