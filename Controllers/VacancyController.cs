using Api.Configuration;
using Api.Controllers.Responses;
using Api.Core;
using Api.Domain.Attributes;
using Api.Domain.Models;
using Api.Domain.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/vacancy")]
public class VacancyController : ControllerBase
{
    [AdminOnly]
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
            return StatusCode(500, new BaseResponse("Could not add Vacancy"));
        }

        return Ok(new BaseResponse("Vacancy added", NoDetailsVacancyDTO.Map(vacancy)));
    }

    [AdminOnly]
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
            return NotFound(new BaseResponse("Vacancy not Found"));
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
            return StatusCode(500, new BaseResponse("Could not update Vacancy"));
        }

        return Ok(new BaseResponse("Vacancy updated", VacancyDTO.Map(vacancy)));
    }

    [AdminOnly]
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
            return NotFound(new BaseResponse("Vacancy not Found"));
        }

        vacancy = await vacancyService.DeleteAsync(id);
        if(vacancy == null)
        {
            return StatusCode(500, new BaseResponse("Could not delete Vacancy"));
        }

        return Ok(new BaseResponse("Vacancy deleted", VacancyDTO.Map(vacancy)));
    }

    [NoAuth]
    [HttpGet]
    public async Task<ActionResult> GetVacancies(
        [FromQuery] string? title,
        [FromQuery] int? page,
        [FromQuery] int? limit,
        [FromServices] IVacancyService vacancyService
    )
    {
        page ??= 0;
        limit ??= 10;

        IEnumerable<Vacancy> vacancies = await vacancyService.GetVacancies(obj => title == null || obj.Title == title, (int)page, (int)limit);
        return Ok(new BaseResponse("Vacancies found", vacancies.Select(obj => VacancySimplifiedDTO.Map(obj))));
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult> GetVacancyDetails(
        [FromRoute] int id,
        [FromServices] BaseService<Vacancy> vacancyService
    )
    {
        Vacancy? vacancy = await vacancyService.GetAsync(id, ["Stages", "Attributes", "DesiredSkills"]);
        if(vacancy == null)
        {
            return NotFound(new BaseResponse("Vacancy not found"));
        }
        return Ok(new BaseResponse("Vacancy found", VacancyDTO.Map(vacancy)));
    }

    [HttpGet]
    [Route("complete/{id}")]
    public async Task<ActionResult> GetFullVacancy(
        [FromRoute] int id,
        [FromServices] BaseService<Vacancy> vacancyService
    )
    {
        Vacancy? vacancy = await vacancyService.GetAsync(id, ["Stages", "Attributes", "DesiredSkills", "DesiredLanguages", "DesiredExperiences", "DesiredEducations"]);
        if(vacancy == null)
        {
            return NotFound(new BaseResponse("Vacancy not found"));
        }
        return Ok(new BaseResponse("Vacancy found", VacancyFullDTO.Map(vacancy)));
    }
}