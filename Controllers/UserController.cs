using Api.Configuration;
using Api.Controllers.Responses;
using Api.Core;
using Api.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/user")]
public class UserController : ControllerBase
{
    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult> GetUserDetails(
        [FromRoute] int id,
        [FromServices] BaseService<User> userService
    )
    {
        if(!(User.Id() == id || User.Admin()))
        {
            return Unauthorized(new BaseResponse("You cannot access this resource"));
        }

        User? user = await userService.GetAsync(id, ["Educations", "Experiences", "Interests", "Languages", "Skills", "Links"]);
        if(user == null)
        {
            return NotFound(new BaseResponse("User not found"));
        }

        return Ok(new BaseResponse("User found", UserDTO.Map(user)));
    }

    [HttpGet]
    [Route("applications")]
    public async Task<ActionResult> GetUserApplications(
        [FromServices] BaseRepository<Application> applicationRepository
    )
    {
        IEnumerable<Vacancy> vacancies = await applicationRepository.Get()
            .Include(obj => obj.Candidate)
            .Include(obj => obj.Vacancy)
            .Where(obj => obj.Candidate.Id == User.Id())
            .Select(obj => obj.Vacancy)
            .ToListAsync();
        
        return Ok(new BaseResponse("Vacancies found", vacancies.Select(obj => EvenSimplerVacancyDTO.Map(obj))));
    }

    [HttpPatch]
    [Route("profile/{id}")]
    public async Task<ActionResult> UpdateUserProfile(
        [FromRoute] int id,
        [FromBody] UserProfileUpdatePayload payload,
        [FromServices] BaseService<User> userService,
        [FromServices] PasswordHasher<User> hasher
    )
    {
        if(!(User.Id() == id))
        {
            return Unauthorized(new BaseResponse("You cannot access this resource"));
        }

        User? user = await userService.GetAsync(id);
        if(user == null)
        {
            return NotFound(new BaseResponse("User not found"));
        }

        if(payload.Password != null && payload.PasswordRepeat != null && payload.OldPassword != null)
        {
            if(payload.Password != payload.PasswordRepeat)
            {
                return BadRequest(new BaseResponse("Passwords don't match"));
            }
            if(hasher.VerifyHashedPassword(user, user.Password, payload.OldPassword) != PasswordVerificationResult.Success)
            {
                return Unauthorized(new BaseResponse("Wrong password"));
            }

            user.Password = payload.Password;
        }

        if(payload.Name != null){user.Name = payload.Name;}
        if(payload.Email != null){user.Email = payload.Email;}
        if(payload.Phone != null){user.Phone = payload.Phone;}
        if(payload.Address != null){user.Address = payload.Address;}
        if(payload.Bio != null){user.Bio = payload.Bio;}

        user = await userService.UpdateAsync(id, user);
        if(user == null)
        {
            return StatusCode(500, new BaseResponse("could not update"));
        }

        return Ok(new BaseResponse("User updated", UserProfileDTO.Map(user)));
    }
}