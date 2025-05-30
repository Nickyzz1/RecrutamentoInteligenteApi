using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Models;

public class SkillCreatePayload
{
    [Required]
    public required int UserId {get;set;}
    [Required]
    public required string Name {get;set;}
}

public class SkillUpdatePayload
{
    public string? Name {get;set;}

}
