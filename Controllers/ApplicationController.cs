using Api.Configuration;
using Api.Controllers.Responses;
using Api.Core;
using Api.Domain.Attributes;
using Api.Domain.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/application")]
public class ApplicationController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> ApplyToVacancy(
        [FromBody] ApplicationCreatePayload payload,
        [FromServices] BaseService<Application> applicationService,
        [FromServices] BaseService<User> userService,
        [FromServices] BaseService<Vacancy> vacancyService
    )
    {
        User? user = await userService.GetAsync(User.Id());

        if(user == null)
        {
            return NotFound(new BaseResponse("User not found"));
        }

        Vacancy? vacancy = await vacancyService.GetAsync(payload.VacancyId);

        if(vacancy == null)
        {
            return NotFound(new BaseResponse("Vacancy not found"));
        }

        Application? application = await applicationService.AddAsync(
            new Application(){
                Note=payload.Note,
                Vacancy=vacancy,
                Candidate=user
            }
        );

        if(application == null)
        {
            return StatusCode(500, new BaseResponse("Could not apply"));
        }

        return Ok(new BaseResponse("Applied successfully", ApplicationDTO.Map(application)));
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult> GetApplication(
        [FromRoute] int id,
        [FromServices] BaseService<Application> applicationService
    )
    {
        Application? application = await applicationService.GetAsync(id, "Candidate");

        if(application == null)
        {
            return NotFound(new BaseResponse("Application not Found"));
        }

        if(application.Candidate.Id != User.Id() && User.Admin() == false)
        {
            return Unauthorized(new BaseResponse("You do not have permission to access this resource"));
        }

        return Ok(new BaseResponse("Application found", ApplicationDTO.Map(application)));
    }


    [HttpPatch]
    [Route("{id}")]
    public async Task<ActionResult> UpdateApplication(
        [FromRoute] int id,
        [FromBody] ApplicationUpdatePayload payload,
        [FromServices] BaseService<Application> applicationService
    )
    {
        Application? application = await applicationService.GetAsync(id, ["Candidate", "Vacancy"]);

        if(application == null)
        {
            return NotFound(new BaseResponse("Application not Found"));
        }

        if(application.Candidate.Id != User.Id())
        {
            return Unauthorized(new BaseResponse("You do not have permission to access this resource"));
        }

        if(payload.Note != null){application.Note = payload.Note;}

        application = await applicationService.UpdateAsync(id, application);
        if(application == null)
        {
            return StatusCode(500, new BaseResponse("Could not update Application"));
        }

        return Ok(new BaseResponse("Application updated", ApplicationDTO.Map(application)));
    }

    [AdminOnly]
    [HttpPatch]
    [Route("status/{id}")]
    public async Task<ActionResult> UpdateApplicationStatus(
        [FromRoute] int id,
        [FromBody] ApplicationStatusUpdatePayload payload,
        [FromServices] BaseService<Application> applicationService,
        [FromServices] BaseService<Stage> stageService
    )
    {
        Application? application = await applicationService.GetAsync(id, "Candidate");

        if(application == null)
        {
            return NotFound(new BaseResponse("Application not Found"));
        }

        if(payload.Status != null){application.Status = (EApplicationStatus)payload.Status;}

        if(payload.DismissalStageId != null)
        {
            Stage? stage = await stageService.GetAsync(payload.DismissalStageId.Value);

            if(stage == null)
            {
                return NotFound(new BaseResponse("Stage not Found"));
            }

            application.DismissalStage = stage;
        }

        application = await applicationService.UpdateAsync(id, application);
        if(application == null)
        {
            return StatusCode(500, new BaseResponse("Could not update application status"));
        }

        return Ok(new BaseResponse("Application status updated", ApplicationDTO.Map(application)));
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteApplication(
        [FromRoute] int id,
        [FromServices] BaseService<Application> applicationService
    )
    {
        Application? application = await applicationService.GetAsync(id, "Candidate");
        if(application == null)
        {
            return NotFound(new BaseResponse("Application not Found"));
        }

        if(application.Candidate.Id != User.Id())
        {
            return Unauthorized(new BaseResponse("You do not have permission to access this resource"));
        }

        application = await applicationService.DeleteAsync(id);
        if(application == null)
        {
            return StatusCode(500, new BaseResponse("Could not delete Application"));
        }

        return Ok(new BaseResponse("Application deleted", ApplicationDTO.Map(application)));
    }
}