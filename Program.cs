using Api.Configuration;

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

app.MapControllers();

app.Run();