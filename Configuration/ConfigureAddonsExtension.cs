using System.IdentityModel.Tokens.Jwt;
using Api.Core.Services;
using Api.Domain.Models;
using Api.Domain.Services;
using Microsoft.AspNetCore.Identity;

namespace Api.Configuration;

public static partial class ServiceCollectionExtension
{
    public static IServiceCollection ConfigureAddons(this IServiceCollection services)
    {
        services.AddScoped<LocalUser>();
        services.AddSingleton<PasswordHasher<User>>();
        return services;
    }
}