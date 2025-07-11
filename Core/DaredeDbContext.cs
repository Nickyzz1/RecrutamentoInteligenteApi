using Api.Domain.Models;
using Api.Core.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Api.Core;

//Do not erase comments, as they are used by the generation script
public class DaredeDbContext(PasswordHasher<User> passwordHasher, DbContextOptions<DaredeDbContext> options) : DbContext(options)
{
    protected PasswordHasher<User> hasher = passwordHasher;

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

        IEnumerable<User> users = [
            new User()
            {
                Id=1,
                Name="Eduardo",
                Email="eduardo@email.com",
                Password="1234",
                Admin=true
            },
            new User()
            {
                Id=2,
                Name="Nicolle",
                Email="nicolle@email.com",
                Password="1234",
                Admin=true
            },
            new User()
            {
                Id=3,
                Name="Adrian",
                Email="adrian@email.com",
                Password="1234",
                Admin=true
            },
            new User()
            {
                Id=4,
                Name="Chico Alonso",
                Email="alonso@email.com",
                Password="1234",
                Phone="41999999991",
                Address="Rua Mariano Procópio, 37",
                Bio="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam aliquam tincidunt accumsan. Curabitur faucibus lorem pharetra dapibus bibendum.",
                Admin=false
            },
            new User()
            {
                Id=5,
                Name="João de Santo Cristo",
                Email="joao@email.com",
                Password="1234",
                Phone="41999999992",
                Address="Praça da Ceilândia",
                Bio="Traficante/Carpinteiro",
                Admin=false
            },
            new User()
            {
                Id=6,
                Name="Domingos",
                Email="domingos@email.com",
                Password="1234",
                Phone="41999999993",
                Address="Rua Juscelino Kubitschek",
                Bio="Padre",
                Admin=false
            },
        ];

        foreach(User user in users)
        {
            user.Password = hasher.HashPassword(user, user.Password);
        }

        modelBuilder.Entity<User>().HasData(users);
    }
}
