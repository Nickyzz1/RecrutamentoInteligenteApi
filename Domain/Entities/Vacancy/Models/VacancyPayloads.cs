using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Models;

public class VacancyCreatePayload
{
    [Required]
    public required string Title {get;set;}
    [Required]
    public required string Description {get;set;}
    [Required]
    public required EWorkDays WorkDays {get;set;}
    [Required]
    public required DateTime WorkStart {get;set;}
    [Required]
    public required DateTime WorkEnd {get;set;}
    [Required]
    public required bool CanApply {get;set;}
}

public class VacancyUpdatePayload
{
    public string? Title {get;set;}
    public string? Description {get;set;}
    public EWorkDays? WorkDays {get;set;}
    public DateTime? WorkStart {get;set;}
    public DateTime? WorkEnd {get;set;}
    public bool? CanApply {get;set;}
}
