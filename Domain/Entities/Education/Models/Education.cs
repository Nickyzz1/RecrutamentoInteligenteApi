namespace Api.Domain.Models;

public class Education : IEntity
{
    public required User User {get;set;}
    public required string Institution {get;set;}
    public required string Course {get;set;}
    public required EEducationStatus Status {get;set;}
    public required DateTime StartDate {get;set;}
    public DateTime? EndDate {get;set;}
    public required EEducationType Type {get;set;}
}
