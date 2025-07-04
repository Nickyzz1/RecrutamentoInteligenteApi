using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Models;

public class EducationCreatePayload
{
    [Required]
    public required int UserId {get;set;}
    [Required]
    public required string Institution {get;set;}
    [Required]
    public required string Course {get;set;}
    [Required]
    public required EEducationStatus Status {get;set;}
    [Required]
    public required DateTime StartDate {get;set;}
    public DateTime? EndDate {get;set;}
    [Required]
    public required EEducationType Type {get;set;}
}

public class EducationUpdatePayload
{
    public string? Institution {get;set;}
    public string? Course {get;set;}
    public EEducationStatus? Status {get;set;}
    public DateTime? StartDate {get;set;}
    public NullableUpdatePayload<DateTime>? EndDate {get;set;}
    public EEducationType? Type {get;set;}

}