using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Models;

public class DesiredEducationCreatePayload
{
    [Required]
    public required int VacancyId {get;set;}
    [Required]
    public required string Name {get;set;}
    [Required]
    public required EEducationType Type {get;set;}
    public bool Required {get;set;} = false;
}

public class DesiredEducationUpdatePayload
{
    public string? Name {get;set;}
    public EEducationType? Type {get;set;}
    public bool? Required {get;set;}

}
