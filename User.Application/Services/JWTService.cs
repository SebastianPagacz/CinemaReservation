using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using User.Domain.Models;

namespace User.Application.Services;

public class JWTService(IConfiguration configuration) : IJWTService
{
    private readonly string _secret = configuration.GetSection("JwtSecret").Value;
    public string GenerateToken(UserModel user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.Role.Name),
            new Claim(ClaimTypes.Name, user.Username)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken
            (
                issuer: "cinema-reservation.pl",
                audience: "cinema-reservation.pl",
                claims: claims,
                signingCredentials: credentials,
                expires: DateTime.UtcNow.AddMinutes(60)
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
