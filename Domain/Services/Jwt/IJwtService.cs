using System.Security.Claims;
using Api.Domain.Models;

namespace Api.Domain.Services;

public record JwtSettings(string SecretKey);

public interface IJwtService
{
    public string GenerateToken(UserDTO user);
    public ClaimsPrincipal ValidateToken(string jwt);
}