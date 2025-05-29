using System.IdentityModel.Tokens.Jwt;
using Api.Core.Services;
using Api.Domain.Services;

namespace Api.Configuration;

public static partial class ServiceCollectionExtension
{
    public static IServiceCollection ConfigureJwt(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddSingleton(new JwtSettings(configuration.GetSection("JwtSettings").GetValue<string>("SecretKey")!));
        services.AddSingleton<JwtSecurityTokenHandler>();
        services.AddScoped<IJwtService, JwtService>();

        return services;

    }
}