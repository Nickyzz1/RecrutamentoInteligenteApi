namespace Api.Domain.Models;

public class DesiredSkill : IEntity
{
    public required Vacancy Vacancy {get;set;}
    public required string Name {get;set;}
    public required bool Required {get;set;}
}
