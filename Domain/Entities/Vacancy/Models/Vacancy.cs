namespace Api.Domain.Models;

public class Vacancy : IEntity
{
    public required string Title {get;set;}
    public required string Description {get;set;}
    public required EWorkDays WorkDays {get;set;}
    public required DateTime WorkStart {get;set;}
    public required DateTime WorkEnd {get;set;}
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public bool CanApply {get;set;} = true;
    public ICollection<Stage> Stages {get;set;} = [];
    public ICollection<VacancyAttribute> Attributes {get;set;} = [];
    public ICollection<DesiredExperience> DesiredExperiences {get;set;} = [];
    public ICollection<DesiredEducation> DesiredEducations {get;set;} = [];
    public ICollection<DesiredSkill> DesiredSkills {get;set;} = [];
    public ICollection<DesiredLanguage> DesiredLanguages {get;set;} = [];
    public ICollection<Application> Applications {get;set;} = [];
}
