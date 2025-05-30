namespace Api.Domain.Models;

public class Vacancy : IEntity
{
    public required string Title {get;set;}
    public required string Description {get;set;}
    public required EWorkDays WorkDays {get;set;}
    public required DateTime WorkStart {get;set;}
    public required DateTime WorkEnd {get;set;}
    public required DateTime CreatedAt {get;set;} = DateTime.Now;
    public required bool CanApply {get;set;} = true;
    public required ICollection<Stage> Stages {get;set;} = [];
    public required ICollection<VacancyAttribute> Attributes {get;set;} = [];
    public required ICollection<DesiredExperience> DesiredExperiences {get;set;} = [];
    public required ICollection<DesiredEducation> DesiredEducations {get;set;} = [];
    public required ICollection<DesiredSkill> DesiredSkills {get;set;} = [];
    public required ICollection<DesiredLanguage> DesiredLanguages {get;set;} = [];
}
