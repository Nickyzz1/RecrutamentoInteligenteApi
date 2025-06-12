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
[Route("api/v1/vacancy/desiredLanguage")]
public class DesiredLanguageController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> AddDesiredLanguage(
        [FromBody] DesiredLanguageCreatePayload payload,
        [FromServices] BaseService<DesiredLanguage> desiredLanguageService,
        [FromServices] BaseService<Vacancy> vacancyService
    )
    {
        Vacancy? vacancy = await vacancyService.GetAsync(payload.VacancyId);

        if(vacancy == null)
        {
            return NotFound(new BaseResponse("Vacancy not found"));
        }

        DesiredLanguage? desiredLanguage = await desiredLanguageService.AddAsync(
            new DesiredLanguage(){
                Name=payload.Name,
                Required=payload.Required,
                Level=payload.Level,
                Vacancy=vacancy
            }
        );

        if(desiredLanguage == null)
        {
            return StatusCode(500, new BaseResponse("Could not add Desired Language"));
        }

        return Ok(new BaseResponse("Desired Language added", DesiredLanguageDTO.Map(desiredLanguage)));
    }

    [HttpPatch]
    [Route("{id}")]
    public async Task<ActionResult> UpdateDesiredLanguage(
        [FromRoute] int id,
        [FromBody] DesiredLanguageUpdatePayload payload,
        [FromServices] BaseService<DesiredLanguage> desiredLanguageService
    )
    {
        DesiredLanguage? desiredLanguage = await desiredLanguageService.GetAsync(id);

        if(desiredLanguage == null)
        {
            return NotFound(new BaseResponse("Desired Language not found"));
        }

        if(payload.Name != null){desiredLanguage.Name = payload.Name;}
        if(payload.Required != null){desiredLanguage.Required = (bool)payload.Required;}
        if(payload.Level != null){desiredLanguage.Level = (EProficiencyLevel)payload.Level;}

        desiredLanguage = await desiredLanguageService.UpdateAsync(id, desiredLanguage);

        if(desiredLanguage == null)
        {
            return StatusCode(500, new BaseResponse("Could not add Desired Language"));
        }

        return Ok(new BaseResponse("Desired Language added", DesiredLanguageDTO.Map(desiredLanguage)));
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteDesiredLanguage(
        [FromRoute] int id,
        [FromServices] BaseService<DesiredLanguage> desiredLanguageService
    )
    {
        DesiredLanguage? desiredLanguage = await desiredLanguageService.GetAsync(id);
        if(desiredLanguage == null)
        {
            return NotFound(new BaseResponse("Desired Language not Found"));
        }

        desiredLanguage = await desiredLanguageService.DeleteAsync(id);
        if(desiredLanguage == null)
        {
            return StatusCode(500, new BaseResponse("Could not delete Desired Language"));
        }

        return Ok(new BaseResponse("Desired Language deleted", DesiredLanguageDTO.Map(desiredLanguage)));
    }
}