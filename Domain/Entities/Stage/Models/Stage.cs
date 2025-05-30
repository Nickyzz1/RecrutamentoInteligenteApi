namespace Api.Domain.Models;

public class Stage : IEntity
{
    public required Vacancy Vacancy {get;set;}
    public required string Description {get;set;}
    public required DateTime StartDate {get;set;}
    public required DateTime EndDate {get;set;}
}
