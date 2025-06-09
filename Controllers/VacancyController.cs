using Api.Configuration;
using Api.Core;
using Api.Domain.Attributes;
using Api.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/vacancy")]
[AdminOnly]
public class VacancyController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> AddVacancy(
        [FromBody] VacancyCreatePayload payload,
        [FromServices] BaseService<Vacancy> vacancyService
    )
    {
        Vacancy? vacancy = await vacancyService.AddAsync(
            new Vacancy(){
                Title=payload.Title,
                Description=payload.Description,
                WorkDays=payload.WorkDays,
                WorkStart=payload.WorkStart,
                WorkEnd=payload.WorkEnd,
                CanApply=payload.CanApply
            }
        );

        if(vacancy == null)
        {
            return StatusCode(500, new {message="Could not add Vacancy"});
        }

        return Ok(new {message="Vacancy added", value=NoDetailsVacancyDTO.Map(vacancy)});
    }

    [HttpPatch]
    [Route("{id}")]
    public async Task<ActionResult> UpdateVacancy(
        [FromRoute] int id,
        [FromBody] VacancyUpdatePayload payload,
        [FromServices] BaseService<Vacancy> vacancyService
    )
    {
        Vacancy? vacancy = await vacancyService.GetAsync(id);
        if(vacancy == null)
        {
            return NotFound(new {message="Vacancy not Found"});
        }

        if(payload.Title != null){vacancy.Title = payload.Title;}
        if(payload.Description != null){vacancy.Description = payload.Description;}
        if(payload.WorkDays != null){vacancy.WorkDays = (EWorkDays)payload.WorkDays;}
        if(payload.WorkStart != null){vacancy.WorkStart = (DateTime)payload.WorkStart;}
        if(payload.WorkEnd != null){vacancy.WorkEnd = (DateTime)payload.WorkEnd;}
        if(payload.CanApply != null){vacancy.CanApply = (bool)payload.CanApply;}

        vacancy = await vacancyService.UpdateAsync(id, vacancy);
        if(vacancy == null)
        {
            return StatusCode(500, new {message="Could not update Vacancy"});
        }

        return Ok(new {message="Vacancy updated", value=VacancyDTO.Map(vacancy)});
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteVacancy(
        [FromRoute] int id,
        [FromServices] BaseService<Vacancy> vacancyService
    )
    {
        Vacancy? vacancy = await vacancyService.GetAsync(id);
        if(vacancy == null)
        {
            return NotFound(new {message="Vacancy not Found"});
        }

        vacancy = await vacancyService.DeleteAsync(id);
        if(vacancy == null)
        {
            return StatusCode(500, new {message="Could not delete Vacancy"});
        }

        return Ok(new {message="Vacancy deleted", value=VacancyDTO.Map(vacancy)});
    }

    [HttpGet]
    public async Task<ActionResult> GetVacancies(
        [FromQuery] string? title,
        [FromQuery] int? page,
        [FromQuery] int? limit,
        [FromServices] BaseService<Vacancy> vacancyService
    )
    {
        await vacancyService.GetAllAsync();
        return Ok();
    }
}