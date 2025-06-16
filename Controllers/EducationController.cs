using Api.Core;
using Api.Domain.Attributes;
using Api.Domain.Models;
using Api.Configuration;
using Api.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Api.Controllers.Responses;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/resume/education")]
public class EducationController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> AddEducation(
        [FromBody] EducationCreatePayload payload,
        [FromServices] BaseService<User> userService,
        [FromServices] BaseService<Education> educationService
    )
    {
        if(payload.UserId != User.Id())
        {
            return Unauthorized(new BaseResponse("You do not have permission to access this resource"));
        }
        User? user = await userService.GetAsync(User.Id());
        if(user == null)
        {
            return NotFound(new BaseResponse("User not found"));
        }

        Education? education = await educationService.AddAsync(
            new Education(){
                Course=payload.Course,
                Institution=payload.Institution,
                StartDate=payload.StartDate,
                EndDate=payload.EndDate,
                Type=payload.Type,
                Status=payload.Status,
                User=user
            }
        );
        if(education == null)
        {
            return StatusCode(500, new BaseResponse("Could not add Education"));
        }

        return Ok(new BaseResponse("Education added", EducationDTO.Map(education)));
    }

    [HttpPatch]
    [Route("{id}")]
    public async Task<ActionResult> UpdateEducation(
        [FromRoute] int id,
        [FromBody] EducationUpdatePayload payload,
        [FromServices] BaseService<Education> educationService
    )
    {
        Education? education = await educationService.GetAsync(id, "User");
        if(education == null)
        {
            return NotFound(new BaseResponse("Education not Found"));
        }

        if(education.User.Id != User.Id())
        {
            return Unauthorized(new BaseResponse("You do not have permission to access this resource"));
        }

        if(payload.Course != null){education.Course = payload.Course;}
        if(payload.Institution != null){education.Institution = payload.Institution;}
        if(payload.StartDate != null){education.StartDate = (DateTime)payload.StartDate;}
        if(payload.EndDate != null){education.EndDate = payload.EndDate.Value;}
        if(payload.Type != null){education.Type = (EEducationType)payload.Type;}
        if(payload.Status != null){education.Status = (EEducationStatus)payload.Status;}

        education = await educationService.UpdateAsync(id, education);
        if(education == null)
        {
            return StatusCode(500, new BaseResponse("Could not update Education"));
        }

        return Ok(new BaseResponse("Education updated", EducationDTO.Map(education)));
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteEducation(
        [FromRoute] int id,
        [FromServices] BaseService<Education> educationService
    )
    {
        Education? education = await educationService.GetAsync(id, "User");
        if(education == null)
        {
            return NotFound(new BaseResponse("Education not Found"));
        }

        if(education.User.Id != User.Id())
        {
            return Unauthorized(new BaseResponse("You do not have permission to access this resource"));
        }

        education = await educationService.DeleteAsync(id);
        if(education == null)
        {
            return StatusCode(500, new BaseResponse("Could not delete Education"));
        }

        return Ok(new BaseResponse("Education deleted", EducationDTO.Map(education)));
    }
}