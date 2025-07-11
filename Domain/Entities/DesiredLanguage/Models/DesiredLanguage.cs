namespace Api.Domain.Models;

public class DesiredLanguage : IEntity
{
    public required Vacancy Vacancy {get;set;}
    public required string Name {get;set;}
    public required EProficiencyLevel Level {get;set;}
    public bool Required {get;set;} = false;
}
