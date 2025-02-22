using System.Security.Claims;
using Core.Models;

namespace Core.Interfaces;

public interface IJwtService
{
    IEnumerable<Claim> GetClaims(User user);
    string CreateToken(IEnumerable<Claim> claims);
}