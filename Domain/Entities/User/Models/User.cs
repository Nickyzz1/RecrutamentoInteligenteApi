namespace Api.Domain.Models;

public class User : IEntity
{
    public required string Name {get;set;}
    public required string Password {get;set;}
    public required string Email {get;set;}
    public string? Phone {get;set;}
    public string? Address {get;set;}
    public string? Bio {get;set;}
    public required bool Admin {get;set;} = true;
    public ICollection<Interest> Interests {get;set;} = [];
    public ICollection<Education> Educations {get;set;} = [];
    public ICollection<Experience> Experiences {get;set;} = [];
    public ICollection<Language> Languages {get;set;} = [];
    public ICollection<Skill> Skills {get;set;} = [];
    public ICollection<Link> Links {get;set;} = [];
    public ICollection<Application> Applications {get;set;} = [];
}
