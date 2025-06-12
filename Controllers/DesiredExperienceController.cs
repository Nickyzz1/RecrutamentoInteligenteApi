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
[Route("api/v1/vacancy/desiredExperience")]
public class DesiredExperienceController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> AddDesiredExperience(
        [FromBody] DesiredExperienceCreatePayload payload,
        [FromServices] BaseService<DesiredExperience> desiredExperienceService,
        [FromServices] BaseService<Vacancy> vacancyService
    )
    {
        Vacancy? vacancy = await vacancyService.GetAsync(payload.VacancyId);

        if(vacancy == null)
        {
            return NotFound(new BaseResponse("Vacancy not found"));
        }

        DesiredExperience? desiredExperience = await desiredExperienceService.AddAsync(
            new DesiredExperience(){
                Name=payload.Name,
                Required=payload.Required,
                Time=payload.Time,
                Vacancy=vacancy
            }
        );

        if(desiredExperience == null)
        {
            return StatusCode(500, new BaseResponse("Could not add Desired Experience"));
        }

        return Ok(new BaseResponse("Desired Experience added", DesiredExperienceDTO.Map(desiredExperience)));
    }

    [HttpPatch]
    [Route("{id}")]
    public async Task<ActionResult> UpdateDesiredExperience(
        [FromRoute] int id,
        [FromBody] DesiredExperienceUpdatePayload payload,
        [FromServices] BaseService<DesiredExperience> desiredExperienceService
    )
    {
        DesiredExperience? desiredExperience = await desiredExperienceService.GetAsync(id);

        if(desiredExperience == null)
        {
            return NotFound(new BaseResponse("Desired Experience not found"));
        }

        if(payload.Name != null){desiredExperience.Name = payload.Name;}
        if(payload.Required != null){desiredExperience.Required = (bool)payload.Required;}
        if(payload.Time != null){desiredExperience.Time = (int)payload.Time;}

        desiredExperience = await desiredExperienceService.UpdateAsync(id, desiredExperience);

        if(desiredExperience == null)
        {
            return StatusCode(500, new BaseResponse("Could not add Desired Experience"));
        }

        return Ok(new BaseResponse("Desired Experience added", DesiredExperienceDTO.Map(desiredExperience)));
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteDesiredExperience(
        [FromRoute] int id,
        [FromServices] BaseService<DesiredExperience> desiredExperienceService
    )
    {
        DesiredExperience? desiredExperience = await desiredExperienceService.GetAsync(id);
        if(desiredExperience == null)
        {
            return NotFound(new BaseResponse("Desired Experience not Found"));
        }

        desiredExperience = await desiredExperienceService.DeleteAsync(id);
        if(desiredExperience == null)
        {
            return StatusCode(500, new BaseResponse("Could not delete Desired Experience"));
        }

        return Ok(new BaseResponse("Desired Experience deleted", DesiredExperienceDTO.Map(desiredExperience)));
    }
}