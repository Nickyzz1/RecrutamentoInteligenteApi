namespace Api.Domain.Models;

public class DesiredEducation : IEntity
{
    public required Vacancy Vacancy {get;set;}
    public required string Name {get;set;}
    public required EEducationType Type {get;set;}
    public bool Required {get;set;} = false;
}
