using Api.Core;
using Api.Core.Repositories;
using Api.Domain.Models;
using Api.Domain.Repositories;

namespace Api.Configuration;

//Do not erase comments, as they are used by the generation script
public static partial class ServiceCollectionExtension
{
    public static IServiceCollection ConfigureEntityRepositories(this IServiceCollection services)
    {
        //Repositories
        services.AddScoped<BaseRepository<Interest>, InterestRepository>();
        services.AddScoped<IInterestRepository, InterestRepository>();

        services.AddScoped<BaseRepository<VacancyAttribute>, VacancyAttributeRepository>();
        services.AddScoped<IVacancyAttributeRepository, VacancyAttributeRepository>();

        services.AddScoped<BaseRepository<DesiredEducation>, DesiredEducationRepository>();
        services.AddScoped<IDesiredEducationRepository, DesiredEducationRepository>();

        services.AddScoped<BaseRepository<DesiredSkill>, DesiredSkillRepository>();
        services.AddScoped<IDesiredSkillRepository, DesiredSkillRepository>();

        services.AddScoped<BaseRepository<DesiredExperience>, DesiredExperienceRepository>();
        services.AddScoped<IDesiredExperienceRepository, DesiredExperienceRepository>();

        services.AddScoped<BaseRepository<DesiredLanguage>, DesiredLanguageRepository>();
        services.AddScoped<IDesiredLanguageRepository, DesiredLanguageRepository>();

        services.AddScoped<BaseRepository<Vacancy>, VacancyRepository>();
        services.AddScoped<IVacancyRepository, VacancyRepository>();

        services.AddScoped<BaseRepository<Stage>, StageRepository>();
        services.AddScoped<IStageRepository, StageRepository>();

        services.AddScoped<BaseRepository<Application>, ApplicationRepository>();
        services.AddScoped<IApplicationRepository, ApplicationRepository>();

        services.AddScoped<BaseRepository<Education>, EducationRepository>();
        services.AddScoped<IEducationRepository, EducationRepository>();

        services.AddScoped<BaseRepository<Link>, LinkRepository>();
        services.AddScoped<ILinkRepository, LinkRepository>();

        services.AddScoped<BaseRepository<Experience>, ExperienceRepository>();
        services.AddScoped<IExperienceRepository, ExperienceRepository>();

        services.AddScoped<BaseRepository<Skill>, SkillRepository>();
        services.AddScoped<ISkillRepository, SkillRepository>();

        services.AddScoped<BaseRepository<Language>, LanguageRepository>();
        services.AddScoped<ILanguageRepository, LanguageRepository>();

        services.AddScoped<BaseRepository<User>, UserRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
