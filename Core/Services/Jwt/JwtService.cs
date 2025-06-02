using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

using Api.Domain.Services;
using Api.Domain.Models;

namespace Api.Core.Services;
public class JwtService : IJwtService
{
    private readonly JwtSecurityTokenHandler _tokenHandler;
    private readonly SymmetricSecurityKey _securityKey;
    private readonly SigningCredentials _credentials;

    public JwtService(
        JwtSecurityTokenHandler tokenHandler,
        JwtSettings settings)
    {
        _tokenHandler = tokenHandler;

        _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.SecretKey));
        _credentials = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha512);
    }

    public string GenerateToken(UserDTO user)
    {
        var claims = new List<Claim>
            {
                new("Id", user.Id.ToString()),
                new("Name", user.Name),
                new("Admin", user.Admin.ToString())
            };

        var SecToken = new JwtSecurityToken(
            "Darede",
            audience: null,
            claims: claims,
            expires: DateTime.Now.AddHours(8),
            signingCredentials: _credentials);

        var token = _tokenHandler.WriteToken(SecToken);

        return token;
    }

    public ClaimsPrincipal ValidateToken(string jwt)
    {
        ClaimsPrincipal? claims = null;

        try
        {
            claims = _tokenHandler.ValidateToken(jwt,
                new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = false,
                    ValidIssuer = "Darede",
                    IssuerSigningKey = _securityKey
                },
                out var validatedToken);

            return claims;
        }
        catch(Exception ex)
        {
            throw new Exception("Cannot validate token", ex);
        }
    }
}