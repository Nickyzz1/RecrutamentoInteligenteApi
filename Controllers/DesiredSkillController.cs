using Api.Configuration;
using Api.Controllers.Responses;
using Api.Core;
using Api.Domain.Attributes;
using Api.Domain.Models;
using Api.Domain.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[AdminOnly]
[ApiController]
[Route("api/v1/vacancy/desiredSkill")]
public class DesiredSkillController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> AddDesiredSkill(
        [FromBody] DesiredSkillCreatePayload payload,
        [FromServices] BaseService<DesiredSkill> desiredSkillService,
        [FromServices] BaseService<Vacancy> vacancyService
    )
    {
        Vacancy? vacancy = await vacancyService.GetAsync(payload.VacancyId);

        if(vacancy == null)
        {
            return NotFound(new BaseResponse("Vacancy not found"));
        }

        DesiredSkill? desiredSkill = await desiredSkillService.AddAsync(
            new DesiredSkill(){
                Name=payload.Name,
                Required=payload.Required,
                Vacancy=vacancy
            }
        );

        if(desiredSkill == null)
        {
            return StatusCode(500, new BaseResponse("Could not add Desired Skill"));
        }

        return Ok(new BaseResponse("Desired Skill added", DesiredSkillDTO.Map(desiredSkill)));
    }

    [HttpPatch]
    [Route("{id}")]
    public async Task<ActionResult> UpdateDesiredSkill(
        [FromRoute] int id,
        [FromBody] DesiredSkillUpdatePayload payload,
        [FromServices] BaseService<DesiredSkill> desiredSkillService
    )
    {
        DesiredSkill? desiredSkill = await desiredSkillService.GetAsync(id);

        if(desiredSkill == null)
        {
            return NotFound(new BaseResponse("Desired Skill not found"));
        }

        if(payload.Name != null){desiredSkill.Name = payload.Name;}
        if(payload.Required != null){desiredSkill.Required = (bool)payload.Required;}

        desiredSkill = await desiredSkillService.UpdateAsync(id, desiredSkill);

        if(desiredSkill == null)
        {
            return StatusCode(500, new BaseResponse("Could not add Desired Skill"));
        }

        return Ok(new BaseResponse("Desired Skill added", DesiredSkillDTO.Map(desiredSkill)));
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteDesiredSkill(
        [FromRoute] int id,
        [FromServices] BaseService<DesiredSkill> desiredSkillService
    )
    {
        DesiredSkill? desiredSkill = await desiredSkillService.GetAsync(id);
        if(desiredSkill == null)
        {
            return NotFound(new BaseResponse("Desired Skill not Found"));
        }

        desiredSkill = await desiredSkillService.DeleteAsync(id);
        if(desiredSkill == null)
        {
            return StatusCode(500, new BaseResponse("Could not delete Desired Skill"));
        }

        return Ok(new BaseResponse("Desired Skill deleted", DesiredSkillDTO.Map(desiredSkill)));
    }
}