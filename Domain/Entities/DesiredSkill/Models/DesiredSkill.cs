namespace Api.Domain.Models;

public class DesiredSkill : IEntity
{
    public required Vacancy Vacancy {get;set;}
    public required string Name {get;set;}
    public bool Required {get;set;} = false;
}
