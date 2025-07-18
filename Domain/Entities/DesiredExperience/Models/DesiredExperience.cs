namespace Api.Domain.Models;

public class DesiredExperience : IEntity
{
    public required Vacancy Vacancy {get;set;}
    public required string Name {get;set;}
    public required int Time {get;set;}
    public bool Required {get;set;} = false;
}
