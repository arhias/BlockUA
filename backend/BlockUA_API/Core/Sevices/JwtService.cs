using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.Models;
using Microsoft.IdentityModel.Tokens;

namespace Core.Sevices;

public class JwtService
{
    private readonly JwtOptions jwtOptions;

    public JwtService(JwtOptions jwtOptions)
    {
        this.jwtOptions = jwtOptions;
    }

    public IEnumerable<Claim> GetClaims(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Email, user.Email!)
        };
        return claims;
    }

    public string CreateToken(IEnumerable<Claim> claims)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            jwtOptions.Issuer,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(jwtOptions.LifetimeInMinutes),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}