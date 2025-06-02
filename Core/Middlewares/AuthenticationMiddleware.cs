using Api.Configuration;
using Api.Core.Services;
using Api.Domain.Attributes;
using Api.Domain.Services;

namespace Api.Core.Middlewares;

public class AuthenticationMiddleware(IJwtService jwtService) : IMiddleware
{
    public readonly IJwtService _jwtService = jwtService;
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var endpoint = context.GetEndpoint();
        if(endpoint != null)
        {
            if(endpoint.Metadata.GetMetadata<NoAuthAttribute>() != null)
            {
                await next.Invoke(context);
                return;
            }
        }

        string? auth = context.Request.Headers.Authorization.FirstOrDefault();

        if(!TryGetBearerToken(auth!, out var token))
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsJsonAsync(new {message="Invalid authorization header"});
            return;
        }

        try 
        {
            context.User = _jwtService.ValidateToken(token!);
        }
        catch(Exception)
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsJsonAsync(new {message="No token"});
            return;
        }
        
        if(endpoint?.Metadata.GetMetadata<AdminOnlyAttribute>() != null)
        {
            if(context.User.Admin())
            {
                await next.Invoke(context);
                return;
            }
            context.Response.StatusCode = 401;
            await context.Response.WriteAsJsonAsync(new {message="No admin permission"});
        }
        await next.Invoke(context);
    }
    
    private static bool TryGetBearerToken(string auth, out string? token)
    {
        var parts = auth.Split(" ");
        if(parts.Length == 2 && parts[0] == "Bearer")
        {
            token = parts[1];
            return true;
        }

        token = null;
        return false;
    }
}