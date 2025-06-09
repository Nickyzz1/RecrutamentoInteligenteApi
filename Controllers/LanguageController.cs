using Api.Core;
using Api.Domain.Attributes;
using Api.Domain.Models;
using Api.Configuration;
using Api.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/resume/Language")]
public class LanguageController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> AddLanguage(
        [FromBody] LanguageCreatePayload payload,
        [FromServices] BaseService<User> userService,
        [FromServices] BaseService<Language> languageService
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

        Language? language = await languageService.AddAsync(
            new Language(){
                Name=payload.Name,
                Level=payload.Level,
                User=user
            }
        );
        if(language == null)
        {
            return StatusCode(500, new {message="Could not add Language"});
        }

        return Ok(new {message="Language added", value=LanguageDTO.Map(language)});
    }

    [HttpPatch]
    [Route("{id}")]
    public async Task<ActionResult> UpdateLanguage(
        [FromRoute] int id,
        [FromBody] LanguageUpdatePayload payload,
        [FromServices] BaseService<Language> languageService
    )
    {
        Language? language = await languageService.GetAsync(id, "User");
        if(language == null)
        {
            return NotFound(new {message="Language not Found"});
        }

        if(language.User.Id != User.Id())
        {
            return Unauthorized(new {message="You do not have permission to access this resource"});
        }

        if(payload.Name != null){language.Name = payload.Name;}
        if(payload.Level != null){language.Level = (EProficiencyLevel)payload.Level;}

        language = await languageService.UpdateAsync(id, language);
        if(language == null)
        {
            return StatusCode(500, new {message="Could not update Language"});
        }

        return Ok(new {message="Language updated", value=LanguageDTO.Map(language)});
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteLanguage(
        [FromRoute] int id,
        [FromServices] BaseService<Language> languageService
    )
    {
        Language? language = await languageService.GetAsync(id, "User");
        if(language == null)
        {
            return NotFound(new {message="Language not Found"});
        }

        if(language.User.Id != User.Id())
        {
            return Unauthorized(new {message="You do not have permission to access this resource"});
        }

        language = await languageService.DeleteAsync(id);
        if(language == null)
        {
            return StatusCode(500, new {message="Could not delete Language"});
        }

        return Ok(new {message="Language deleted", value=LanguageDTO.Map(language)});
    }
}