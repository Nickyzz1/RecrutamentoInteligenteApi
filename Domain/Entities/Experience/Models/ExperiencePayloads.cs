using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Models;

public class ExperienceCreatePayload
{
    [Required]
    public required int UserId {get;set;}
    [Required]
    public required string Company {get;set;}
    [Required]
    public required string Role {get;set;}
    [Required]
    public required string Description {get;set;}
    [Required]
    public required string Location {get;set;}
    [Required]
    public required DateTime StartDate {get;set;}
    public DateTime? EndDate {get;set;}
}

public class ExperienceUpdatePayload
{
    public string? Company {get;set;}
    public string? Role {get;set;}
    public string? Description {get;set;}
    public string? Location {get;set;}
    public DateTime? StartDate {get;set;}
    public NullableUpdatePayload<DateTime>? EndDate {get;set;}

}
