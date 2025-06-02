using Api.Configuration;
using Api.Core.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .ConfigureDatabase(builder.Configuration)
    .ConfigureJwt(builder.Configuration)
    .ConfigureMainConfigs()
    .ConfigureEntityRepositories()
    .ConfigureEntityServices()
    .ConfigureAddons();

var app = builder.Build();

app.UseCors(cors => cors
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseMiddleware<AuthenticationMiddleware>();

app.MapControllers();

app.Run();