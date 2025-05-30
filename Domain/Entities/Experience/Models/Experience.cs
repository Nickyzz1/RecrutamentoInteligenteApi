namespace Api.Domain.Models;

public class Experience : IEntity
{
    public required User User {get;set;}
    public required string Company {get;set;}
    public required string Role {get;set;}
    public required string Description {get;set;}
    public required string Location {get;set;}
    public required DateTime StartDate {get;set;}
    public DateTime? EndDate {get;set;}
}
