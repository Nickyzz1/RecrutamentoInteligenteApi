using Api.Core;
using Api.Domain.Attributes;
using Api.Domain.Models;
using Api.Configuration;
using Api.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/resume/experience")]
public class ExperienceController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> AddExperience(
        [FromBody] ExperienceCreatePayload payload,
        [FromServices] BaseService<User> userService,
        [FromServices] BaseService<Experience> experienceService
    )
    {
        if(payload.UserId != User.Id())
        {
            return Unauthorized(new {message="You do not have permission to access this resource"});
        }
        User? user = await userService.GetAsync(User.Id());
        if(user == null)
        {
            return NotFound(new {message="User not found"});
        }

        Experience? experience = await experienceService.AddAsync(
            new Experience(){
                Role=payload.Role,
                Company=payload.Company,
                StartDate=payload.StartDate,
                EndDate=payload.EndDate,
                Description=payload.Description,
                Location=payload.Location,
                User=user
            }
        );
        if(experience == null)
        {
            return StatusCode(500, new {message="Could not add Experience"});
        }

        return Ok(new {message="Experience added", value=ExperienceDTO.Map(experience)});
    }

    [HttpPatch]
    [Route("{id}")]
    public async Task<ActionResult> UpdateExperience(
        [FromRoute] int id,
        [FromBody] ExperienceUpdatePayload payload,
        [FromServices] BaseService<Experience> experienceService
    )
    {
        Experience? experience = await experienceService.GetAsync(id, "User");
        if(experience == null)
        {
            return NotFound(new {message="Experience not Found"});
        }

        if(experience.User.Id != User.Id())
        {
            return Unauthorized(new {message="You do not have permission to access this resource"});
        }

        if(payload.Role != null){experience.Role = payload.Role;}
        if(payload.Company != null){experience.Company = payload.Company;}
        if(payload.StartDate != null){experience.StartDate = (DateTime)payload.StartDate;}
        if(payload.EndDate != null){experience.EndDate = payload.EndDate.Value;}
        if(payload.Description != null){experience.Description = payload.Description;}
        if(payload.Location != null){experience.Location = payload.Location;}

        experience = await experienceService.UpdateAsync(id, experience);
        if(experience == null)
        {
            return StatusCode(500, new {message="Could not update Experience"});
        }

        return Ok(new {message="Experience updated", value=ExperienceDTO.Map(experience)});
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteExperience(
        [FromRoute] int id,
        [FromServices] BaseService<Experience> experienceService
    )
    {
        Experience? experience = await experienceService.GetAsync(id, "User");
        if(experience == null)
        {
            return NotFound(new {message="Experience not Found"});
        }

        if(experience.User.Id != User.Id())
        {
            return Unauthorized(new {message="You do not have permission to access this resource"});
        }

        experience = await experienceService.DeleteAsync(id);
        if(experience == null)
        {
            return StatusCode(500, new {message="Could not delete Experience"});
        }

        return Ok(new {message="Experience deleted", value=ExperienceDTO.Map(experience)});
    }
}