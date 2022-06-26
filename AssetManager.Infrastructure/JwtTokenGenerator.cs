using AssetManager.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AssetManager.Application.Authentication;

internal class JwtTokenGenerator : IJwtTokenGenerator
{
    public string GenerateToken(User user)
    {
        // Generate JWT Token
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.FirstName),
            new Claim(ClaimTypes.Surname, user.LastName),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };

        var securityToken = new JwtSecurityToken(
            issuer: "AssetManager",
            audience: "AssetManager",
            claims: claims,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes("superSecretKey@345")),
                SecurityAlgorithms.HmacSha256Signature
            )
        );

        // return token
        return new JwtSecurityTokenHandler().WriteToken(securityToken);

    }
}
