using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Models;

public class LinkCreatePayload
{
    [Required]
    public required int UserId {get;set;}
    [Required]
    public required string Url {get;set;}
    [Required]
    public required string Description {get;set;}
}

public class LinkUpdatePayload
{
    public string? Url {get;set;}
    public string? Description {get;set;}

}
