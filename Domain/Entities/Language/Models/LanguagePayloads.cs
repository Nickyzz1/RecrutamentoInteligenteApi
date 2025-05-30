using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Models;

public class LanguageCreatePayload
{
    [Required]
    public required int UserId {get;set;}
    [Required]
    public required string Name {get;set;}
    [Required]
    public required EProficiencyLevel Level {get;set;}
}

public class LanguageUpdatePayload
{
    public string? Name {get;set;}
    public EProficiencyLevel? Level {get;set;}

}
