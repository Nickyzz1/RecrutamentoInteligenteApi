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
[Route("api/v1/vacancy/desiredEducation")]
public class DesiredEducationController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> AddDesiredEducation(
        [FromBody] DesiredEducationCreatePayload payload,
        [FromServices] BaseService<DesiredEducation> desiredEducationService,
        [FromServices] BaseService<Vacancy> vacancyService
    )
    {
        Vacancy? vacancy = await vacancyService.GetAsync(payload.VacancyId);

        if(vacancy == null)
        {
            return NotFound(new BaseResponse("Vacancy not found"));
        }

        DesiredEducation? desiredEducation = await desiredEducationService.AddAsync(
            new DesiredEducation(){
                Name=payload.Name,
                Required=payload.Required,
                Type=payload.Type,
                Vacancy=vacancy
            }
        );

        if(desiredEducation == null)
        {
            return StatusCode(500, new BaseResponse("Could not add Desired Education"));
        }

        return Ok(new BaseResponse("Desired Education added", DesiredEducationDTO.Map(desiredEducation)));
    }

    [HttpPatch]
    [Route("{id}")]
    public async Task<ActionResult> UpdateDesiredEducation(
        [FromRoute] int id,
        [FromBody] DesiredEducationUpdatePayload payload,
        [FromServices] BaseService<DesiredEducation> desiredEducationService
    )
    {
        DesiredEducation? desiredEducation = await desiredEducationService.GetAsync(id);

        if(desiredEducation == null)
        {
            return NotFound(new BaseResponse("Desired Education not found"));
        }

        if(payload.Name != null){desiredEducation.Name = payload.Name;}
        if(payload.Required != null){desiredEducation.Required = (bool)payload.Required;}
        if(payload.Type != null){desiredEducation.Type = (EEducationType)payload.Type;}

        desiredEducation = await desiredEducationService.UpdateAsync(id, desiredEducation);

        if(desiredEducation == null)
        {
            return StatusCode(500, new BaseResponse("Could not add Desired Education"));
        }

        return Ok(new BaseResponse("Desired Education added", DesiredEducationDTO.Map(desiredEducation)));
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteDesiredEducation(
        [FromRoute] int id,
        [FromServices] BaseService<DesiredEducation> desiredEducationService
    )
    {
        DesiredEducation? desiredEducation = await desiredEducationService.GetAsync(id);
        if(desiredEducation == null)
        {
            return NotFound(new BaseResponse("Desired Education not Found"));
        }

        desiredEducation = await desiredEducationService.DeleteAsync(id);
        if(desiredEducation == null)
        {
            return StatusCode(500, new BaseResponse("Could not delete Desired Education"));
        }

        return Ok(new BaseResponse("Desired Education deleted", DesiredEducationDTO.Map(desiredEducation)));
    }
}