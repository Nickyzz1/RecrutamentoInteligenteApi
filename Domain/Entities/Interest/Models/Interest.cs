namespace Api.Domain.Models;

public class Interest : IEntity
{
    public required string Name {get;set;}
    public required User User {get;set;}
}
