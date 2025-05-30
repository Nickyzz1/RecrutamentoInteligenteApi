using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Models;

public class StageCreatePayload
{
    [Required]
    public required int VacancyId {get;set;}
    [Required]
    public required string Description {get;set;}
    [Required]
    public required DateTime StartDate {get;set;}
    [Required]
    public required DateTime EndDate {get;set;}
}

public class StageUpdatePayload
{
    public string? Description {get;set;}
    public DateTime? StartDate {get;set;}
    public DateTime? EndDate {get;set;}

}
