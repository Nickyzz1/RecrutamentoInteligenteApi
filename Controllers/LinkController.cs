using Api.Core;
using Api.Domain.Attributes;
using Api.Domain.Models;
using Api.Configuration;
using Api.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Api.Controllers.Responses;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/resume/Link")]
public class LinkController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> AddLink(
        [FromBody] LinkCreatePayload payload,
        [FromServices] BaseService<User> userService,
        [FromServices] BaseService<Link> linkService
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

        Link? link = await linkService.AddAsync(
            new Link(){
                Url=payload.Url,
                Description=payload.Description,
                User=user
            }
        );
        if(link == null)
        {
            return StatusCode(500, new BaseResponse("Could not add Link"));
        }

        return Ok(new BaseResponse("Link added", LinkDTO.Map(link)));
    }

    [HttpPatch]
    [Route("{id}")]
    public async Task<ActionResult> UpdateLink(
        [FromRoute] int id,
        [FromBody] LinkUpdatePayload payload,
        [FromServices] BaseService<Link> linkService
    )
    {
        Link? link = await linkService.GetAsync(id, "User");
        if(link == null)
        {
            return NotFound(new BaseResponse("Link not Found"));
        }

        if(link.User.Id != User.Id())
        {
            return Unauthorized(new BaseResponse("You do not have permission to access this resource"));
        }

        if(payload.Url != null){link.Url = payload.Url;}
        if(payload.Description != null){link.Description = payload.Description;}

        link = await linkService.UpdateAsync(id, link);
        if(link == null)
        {
            return StatusCode(500, new BaseResponse("Could not update Link"));
        }

        return Ok(new BaseResponse("Link updated", LinkDTO.Map(link)));
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteLink(
        [FromRoute] int id,
        [FromServices] BaseService<Link> linkService
    )
    {
        Link? link = await linkService.GetAsync(id, "User");
        if(link == null)
        {
            return NotFound(new BaseResponse("Link not Found"));
        }

        if(link.User.Id != User.Id())
        {
            return Unauthorized(new BaseResponse("You do not have permission to access this resource"));
        }

        link = await linkService.DeleteAsync(id);
        if(link == null)
        {
            return StatusCode(500, new BaseResponse("Could not delete Link"));
        }

        return Ok(new BaseResponse("Link deleted", LinkDTO.Map(link)));
    }
}