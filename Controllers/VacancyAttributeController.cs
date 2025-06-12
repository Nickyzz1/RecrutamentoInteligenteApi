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
[Route("api/v1/vacancy")]
public class VacancyAttributeController : ControllerBase
{
    [HttpPost]
    [Route("requirement")]
    public async Task<ActionResult> AddRequirement(
        [FromBody] VacancyAttributeCreatePayload payload,
        [FromServices] BaseService<VacancyAttribute> attributeService,
        [FromServices] BaseService<Vacancy> vacancyService
    )
    {
        Vacancy? vacancy = await vacancyService.GetAsync(payload.VacancyId);

        if(vacancy == null)
        {
            return NotFound(new BaseResponse("Vacancy not found"));
        }

        VacancyAttribute? vacancyAttribute = await attributeService.AddAsync(
            new VacancyAttribute(){
                Name=payload.Name,
                Type=EAttributeType.Requirement,
                Vacancy=vacancy
            }
        );

        if(vacancyAttribute == null)
        {
            return StatusCode(500, new BaseResponse("Could not add requirement"));
        }

        return Ok(new BaseResponse("Requirement added", NoTypeAttributeDTO.Map(vacancyAttribute)));
    }

    [HttpDelete]
    [Route("requirement/{id}")]
    public async Task<ActionResult> DeleteRequirement(
        [FromRoute] int id,
        [FromServices] BaseService<VacancyAttribute> attributeService
    )
    {
        VacancyAttribute? vacancyAttribute = await attributeService.DeleteAsync(id);

        if(vacancyAttribute == null)
        {
            return StatusCode(500, new BaseResponse("Could not delete requirement"));
        }

        return Ok(new BaseResponse("Requirement deleted", NoTypeAttributeDTO.Map(vacancyAttribute)));
    }

    [HttpPost]
    [Route("assignment")]
    public async Task<ActionResult> AddAssignment(
        [FromBody] VacancyAttributeCreatePayload payload,
        [FromServices] BaseService<VacancyAttribute> attributeService,
        [FromServices] BaseService<Vacancy> vacancyService
    )
    {
        Vacancy? vacancy = await vacancyService.GetAsync(payload.VacancyId);

        if(vacancy == null)
        {
            return NotFound(new BaseResponse("Vacancy not found"));
        }

        VacancyAttribute? vacancyAttribute = await attributeService.AddAsync(
            new VacancyAttribute(){
                Name=payload.Name,
                Type=EAttributeType.Assignment,
                Vacancy=vacancy
            }
        );

        if(vacancyAttribute == null)
        {
            return StatusCode(500, new BaseResponse("Could not add assignment"));
        }

        return Ok(new BaseResponse("Assignment added", NoTypeAttributeDTO.Map(vacancyAttribute)));
    }

    [HttpDelete]
    [Route("assignment/{id}")]
    public async Task<ActionResult> DeleteAssignment(
        [FromRoute] int id,
        [FromServices] BaseService<VacancyAttribute> attributeService
    )
    {
        VacancyAttribute? vacancyAttribute = await attributeService.DeleteAsync(id);

        if(vacancyAttribute == null)
        {
            return StatusCode(500, new BaseResponse("Could not delete assignment"));
        }

        return Ok(new BaseResponse("Assignment deleted", NoTypeAttributeDTO.Map(vacancyAttribute)));
    }

    [HttpPost]
    [Route("benefit")]
    public async Task<ActionResult> AddBenefit(
        [FromBody] VacancyAttributeCreatePayload payload,
        [FromServices] BaseService<VacancyAttribute> attributeService,
        [FromServices] BaseService<Vacancy> vacancyService
    )
    {
        Vacancy? vacancy = await vacancyService.GetAsync(payload.VacancyId);

        if(vacancy == null)
        {
            return NotFound(new BaseResponse("Vacancy not found"));
        }

        VacancyAttribute? vacancyAttribute = await attributeService.AddAsync(
            new VacancyAttribute(){
                Name=payload.Name,
                Type=EAttributeType.Benefit,
                Vacancy=vacancy
            }
        );

        if(vacancyAttribute == null)
        {
            return StatusCode(500, new BaseResponse("Could not add benefit"));
        }

        return Ok(new BaseResponse("Benefit added", NoTypeAttributeDTO.Map(vacancyAttribute)));
    }

    [HttpDelete]
    [Route("benefit/{id}")]
    public async Task<ActionResult> DeleteBenefit(
        [FromRoute] int id,
        [FromServices] BaseService<VacancyAttribute> attributeService
    )
    {
        VacancyAttribute? vacancyAttribute = await attributeService.DeleteAsync(id);

        if(vacancyAttribute == null)
        {
            return StatusCode(500, new BaseResponse("Could not delete benefit"));
        }

        return Ok(new BaseResponse("Benefit deleted", NoTypeAttributeDTO.Map(vacancyAttribute)));
    }
}