namespace Api.Domain.Models;

public class Skill : IEntity
{
    public required User User {get;set;}
    public required string Name {get;set;}
}
