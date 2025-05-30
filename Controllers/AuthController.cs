using Api.Domain.Attributes;
using Api.Domain.Models;
using Api.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1")]
[NoAuth]
public class AuthController : ControllerBase
{

    [HttpPost]
    [Route("auth")]
    public async Task<ActionResult> Login(
        [FromBody] UserAuthPayload data,
        [FromServices] IJwtService jwtService,
        [FromServices] IUserService userService
    )
    {
        User? user = await userService.Auth(data.Email, data.Password);

        if(user == null)
        {
            return NotFound(new {message="User not found"});
        }

        return Ok(new {token=jwtService.GenerateToken(UserDTO.Map(user))});
    }

    [HttpPost]
    [Route("register")]
    public async Task<ActionResult> Register([FromBody] UserRegisterPayload data, [FromServices] IUserService userService)
    {
        if(data.Password != data.PasswordRepeat)
        {
            return BadRequest(new {message="Passwords don't match"});
        }

        if(await userService.Register(data))
        {
            return Ok(new {message="User created"});
        }

        throw new Exception("Could not create user");
    }
}