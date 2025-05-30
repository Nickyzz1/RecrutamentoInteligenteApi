using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Models;

public class DesiredLanguageCreatePayload
{
    [Required]
    public required int VacancyId {get;set;}
    [Required]
    public required string Name {get;set;}
    [Required]
    public required EProficiencyLevel Level {get;set;}
    [Required]
    public required bool Required {get;set;}
}

public class DesiredLanguageUpdatePayload
{
    public string? Name {get;set;}
    public EProficiencyLevel? Level {get;set;}
    public bool? Required {get;set;}

}
