namespace Api.Domain.Models;

public class Language : IEntity
{
    public required User User {get;set;}
    public required string Name {get;set;}
    public required EProficiencyLevel Level {get;set;}
}
