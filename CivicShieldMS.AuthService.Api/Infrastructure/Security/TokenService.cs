using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using CivicShieldMS.AuthService.Api.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace CivicShieldMS.AuthService.Api.Infrastructure.Security
{
    public class TokenService(IConfiguration configuration) : ITokenService
    {
        private readonly IConfiguration _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        public string CreateToken(ApplicationUser user, IEnumerable<string> Roles)
        {
            var claim = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.UserName!),
                new Claim(ClaimTypes.Email,user.Email!),
            };
            foreach (var role in Roles)
            {
                claim.Add(new Claim(ClaimTypes.Role, role));
            }
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claim,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
