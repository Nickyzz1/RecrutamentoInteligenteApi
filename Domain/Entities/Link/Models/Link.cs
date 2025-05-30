namespace Api.Domain.Models;

public class Link : IEntity
{
    public required User User {get;set;}
    public required string Url {get;set;}
    public required string Description {get;set;}
}
