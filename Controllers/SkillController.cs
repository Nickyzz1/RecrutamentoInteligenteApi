using Api.Core;
using Api.Domain.Attributes;
using Api.Domain.Models;
using Api.Configuration;
using Api.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/resume/skill")]
public class SkillController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> AddSkill(
        [FromBody] SkillCreatePayload payload,
        [FromServices] BaseService<User> userService,
        [FromServices] BaseService<Skill> skillService
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

        Skill? skill = await skillService.AddAsync(
            new Skill(){
                Name=payload.Name,
                User=user
            }
        );
        if(skill == null)
        {
            return StatusCode(500, new {message="Could not add skill"});
        }

        return Ok(new {message="Skill added", value=SkillDTO.Map(skill)});
    }

    [HttpPatch]
    [Route("{id}")]
    public async Task<ActionResult> UpdateSkill(
        [FromRoute] int id,
        [FromBody] SkillUpdatePayload payload,
        [FromServices] BaseService<Skill> skillService
    )
    {
        Skill? skill = await skillService.GetAsync(id, "User");
        if(skill == null)
        {
            return NotFound(new {message="Skill not Found"});
        }

        if(skill.User.Id != User.Id())
        {
            return Unauthorized(new {message="You do not have permission to access this resource"});
        }

        if(payload.Name != null){skill.Name = payload.Name;}

        skill = await skillService.UpdateAsync(id, skill);
        if(skill == null)
        {
            return StatusCode(500, new {message="Could not update skill"});
        }

        return Ok(new {message="Skill updated", value=SkillDTO.Map(skill)});
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteSkill(
        [FromRoute] int id,
        [FromServices] BaseService<Skill> skillService
    )
    {
        Skill? skill = await skillService.GetAsync(id, "User");
        if(skill == null)
        {
            return NotFound(new {message="Skill not Found"});
        }

        if(skill.User.Id != User.Id())
        {
            return Unauthorized(new {message="You do not have permission to access this resource"});
        }

        skill = await skillService.DeleteAsync(id);
        if(skill == null)
        {
            return StatusCode(500, new {message="Could not delete skill"});
        }

        return Ok(new {message="Skill deleted", value=SkillDTO.Map(skill)});
    }
}