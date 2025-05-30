using Api.Domain.Models;
using Api.Core.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Api.Core;

//Do not erase comments, as they are used by the generation script
public class DaredeDbContext : DbContext
{
    public DaredeDbContext() {}

    public DaredeDbContext(DbContextOptions<DaredeDbContext> options)
    : base(options)
    {}

    //DbSets
    public virtual DbSet<Interest> InterestList {get; set;}
    public virtual DbSet<VacancyAttribute> VacancyAttributeList {get; set;}
    public virtual DbSet<DesiredEducation> DesiredEducationList {get; set;}
    public virtual DbSet<DesiredSkill> DesiredSkillList {get; set;}
    public virtual DbSet<DesiredExperience> DesiredExperienceList {get; set;}
    public virtual DbSet<DesiredLanguage> DesiredLanguageList {get; set;}
    public virtual DbSet<Vacancy> VacancyList {get; set;}
    public virtual DbSet<Stage> StageList {get; set;}
    public virtual DbSet<Application> ApplicationList {get; set;}
    public virtual DbSet<Education> EducationList {get; set;}
    public virtual DbSet<Link> LinkList {get; set;}
    public virtual DbSet<Experience> ExperienceList {get; set;}
    public virtual DbSet<Skill> SkillList {get; set;}
    public virtual DbSet<Language> LanguageList {get; set;}
    public virtual DbSet<User> UserList {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Mapping
        modelBuilder.ApplyConfiguration(new InterestClassMap());
        modelBuilder.ApplyConfiguration(new VacancyAttributeClassMap());
        modelBuilder.ApplyConfiguration(new DesiredEducationClassMap());
        modelBuilder.ApplyConfiguration(new DesiredSkillClassMap());
        modelBuilder.ApplyConfiguration(new DesiredExperienceClassMap());
        modelBuilder.ApplyConfiguration(new DesiredLanguageClassMap());
        modelBuilder.ApplyConfiguration(new VacancyClassMap());
        modelBuilder.ApplyConfiguration(new StageClassMap());
        modelBuilder.ApplyConfiguration(new ApplicationClassMap());
        modelBuilder.ApplyConfiguration(new EducationClassMap());
        modelBuilder.ApplyConfiguration(new LinkClassMap());
        modelBuilder.ApplyConfiguration(new ExperienceClassMap());
        modelBuilder.ApplyConfiguration(new SkillClassMap());
        modelBuilder.ApplyConfiguration(new LanguageClassMap());
        modelBuilder.ApplyConfiguration(new UserClassMap());
    }
}
