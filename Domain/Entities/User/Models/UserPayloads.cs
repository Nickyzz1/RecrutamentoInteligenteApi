using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Models;

public class UserResumePayload
{
    [Required]
    public required string Name {get;set;}
    [Required]
    public required string Address {get;set;}
    [Required]
    public required string Phone {get;set;}
    [Required]
    public required ICollection<ExperienceCreatePayload> Experiences {get;set;}
    [Required]
    public required ICollection<EducationCreatePayload> Educations {get;set;}
    [Required]
    public required ICollection<LanguageCreatePayload> Languages {get;set;}
    [Required]
    public required ICollection<LinkCreatePayload> Links {get;set;}
    [Required]
    public required ICollection<SkillCreatePayload> Skills {get;set;}
}

public class UserRegisterPayload
{
    [Required]
    public required string Name {get;set;}
    [Required]
    public required string Password {get;set;}
    [Required]
    public required string PasswordRepeat {get;set;}
    [Required]
    public required string Email {get;set;}
    public string? Phone {get;set;}
}

public class UserAuthPayload
{
    [Required]
    public required string Email {get;set;}
    [Required]
    public required string Password {get;set;}
}

