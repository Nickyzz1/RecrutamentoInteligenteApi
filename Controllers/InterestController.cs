using Api.Configuration;
using Api.Controllers.Responses;
using Api.Core;
using Api.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/user/interest")]
public class InterestController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> AddInterest(
        [FromBody] InterestCreatePayload payload,
        [FromServices] BaseService<User> userService,
        [FromServices] BaseService<Interest> interestService
    )
    {
        User? user = await userService.GetAsync(User.Id());
        if(user == null)
        {
            return NotFound(new BaseResponse("User not found"));
        }

        Interest? interest = await interestService.AddAsync(
            new Interest(){
                Name=payload.Name,
                User=user
            }
        );
        if(interest == null)
        {
            return StatusCode(500, new BaseResponse("Could not add interest"));
        }

        return Ok(new BaseResponse("Interest added", InterestDTO.Map(interest)));
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteInterest(
        [FromRoute] int id,
        [FromServices] BaseService<Interest> interestService
    )
    {
        Interest? interest = await interestService.GetAsync(id, "User");
        if(interest == null)
        {
            return NotFound(new BaseResponse("Interest not found"));
        }
        
        if(interest.User.Id != User.Id())
        {
            return Unauthorized(new BaseResponse("You cannot delete this object"));
        }

        interest = await interestService.DeleteAsync(id);
        if(interest == null)
        {
            return StatusCode(500, new BaseResponse("Could not delete interest"));
        }

        return Ok(new BaseResponse("Interest deleted", InterestDTO.Map(interest)));
    }
}