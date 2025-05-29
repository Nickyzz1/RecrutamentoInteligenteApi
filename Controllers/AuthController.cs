using Api.Domain.Attributes;
using Api.Domain.Models;
using Api.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[NoAuth]
public class AuthController(
    IUserService userService,
    IJwtService jwtService
) : ControllerBase
{
    private readonly IUserService userService = userService;
    private readonly IJwtService jwtService = jwtService;
    [HttpPost]
    [Route("/auth")]
    public async Task<ActionResult> Login([FromBody] UserAuthPayload auth)
    {
        User? user = await userService.Auth(auth.Email, auth.Password);

        if(user == null)
        {
            return NotFound(new {message="User not found"});
        }

        return Ok(new {token=jwtService.GenerateToken(UserDTO.Map(user))});
    }
}