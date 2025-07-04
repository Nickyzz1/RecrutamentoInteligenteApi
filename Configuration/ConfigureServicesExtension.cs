using Api.Core.Services;
using Api.Core;
using Api.Domain.Models;
using Api.Domain.Services;

namespace Api.Configuration;

//Do not erase comments, as they are used by the generation script
public static partial class ServiceCollectionExtension
{
    public static IServiceCollection ConfigureEntityServices(this IServiceCollection services)
    {
        //Services
        services.AddScoped<IInterestService, InterestService>();
        services.AddScoped<BaseService<Interest>, InterestService>();

        services.AddScoped<IVacancyAttributeService, VacancyAttributeService>();
        services.AddScoped<BaseService<VacancyAttribute>, VacancyAttributeService>();

        services.AddScoped<IDesiredEducationService, DesiredEducationService>();
        services.AddScoped<BaseService<DesiredEducation>, DesiredEducationService>();

        services.AddScoped<IDesiredSkillService, DesiredSkillService>();
        services.AddScoped<BaseService<DesiredSkill>, DesiredSkillService>();

        services.AddScoped<IDesiredExperienceService, DesiredExperienceService>();
        services.AddScoped<BaseService<DesiredExperience>, DesiredExperienceService>();

        services.AddScoped<IDesiredLanguageService, DesiredLanguageService>();
        services.AddScoped<BaseService<DesiredLanguage>, DesiredLanguageService>();

        services.AddScoped<IVacancyService, VacancyService>();
        services.AddScoped<BaseService<Vacancy>, VacancyService>();

        services.AddScoped<IStageService, StageService>();
        services.AddScoped<BaseService<Stage>, StageService>();

        services.AddScoped<IApplicationService, ApplicationService>();
        services.AddScoped<BaseService<Application>, ApplicationService>();

        services.AddScoped<IEducationService, EducationService>();
        services.AddScoped<BaseService<Education>, EducationService>();

        services.AddScoped<ILinkService, LinkService>();
        services.AddScoped<BaseService<Link>, LinkService>();

        services.AddScoped<IExperienceService, ExperienceService>();
        services.AddScoped<BaseService<Experience>, ExperienceService>();

        services.AddScoped<ISkillService, SkillService>();
        services.AddScoped<BaseService<Skill>, SkillService>();

        services.AddScoped<ILanguageService, LanguageService>();
        services.AddScoped<BaseService<Language>, LanguageService>();

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<BaseService<User>, UserService>();

        return services;
    }
}
