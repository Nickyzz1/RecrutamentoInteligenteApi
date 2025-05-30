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

        services.AddScoped<IVacancyAttributeService, VacancyAttributeService>();

        services.AddScoped<IDesiredEducationService, DesiredEducationService>();

        services.AddScoped<IDesiredSkillService, DesiredSkillService>();

        services.AddScoped<IDesiredExperienceService, DesiredExperienceService>();

        services.AddScoped<IDesiredLanguageService, DesiredLanguageService>();

        services.AddScoped<IVacancyService, VacancyService>();

        services.AddScoped<IStageService, StageService>();

        services.AddScoped<IApplicationService, ApplicationService>();

        services.AddScoped<IEducationService, EducationService>();

        services.AddScoped<ILinkService, LinkService>();

        services.AddScoped<IExperienceService, ExperienceService>();

        services.AddScoped<ISkillService, SkillService>();

        services.AddScoped<ILanguageService, LanguageService>();

        services.AddScoped<IUserService, UserService>();

        return services;
    }
}
