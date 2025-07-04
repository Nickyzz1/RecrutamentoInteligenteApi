using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Models;

public class DesiredExperienceCreatePayload
{
    [Required]
    public required int VacancyId {get;set;}
    [Required]
    public required string Name {get;set;}
    [Required]
    public required int Time {get;set;}
    public bool Required {get;set;} = false;
}

public class DesiredExperienceUpdatePayload
{
    public string? Name {get;set;}
    public int? Time {get;set;}
    public bool? Required {get;set;}

}
