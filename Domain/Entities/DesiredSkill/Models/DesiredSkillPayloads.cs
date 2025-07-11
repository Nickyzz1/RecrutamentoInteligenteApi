using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Models;

public class DesiredSkillCreatePayload
{
    [Required]
    public required int VacancyId {get;set;}
    [Required]
    public required string Name {get;set;}
    public bool Required {get;set;} = false;
}

public class DesiredSkillUpdatePayload
{
    public string? Name {get;set;}
    public bool? Required {get;set;}

}
