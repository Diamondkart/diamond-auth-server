using DiamondAuthServer.ApplicationCore;
using DiamondAuthServer.Domain.Exceptions;
using DiamondAuthServer.Persistence;
using DiamondAuthServer.WebAPI.Extensions;
using DiamondIdentity.Configurations;
using Duende.IdentityServer.Test;

// start building configuration, host, etc ..
var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureAppConfiguration(c => c.BuildConfiguration(args));

builder.Services.AddIdentityServer()
        .AddDeveloperSigningCredential()
        .AddInMemoryApiScopes(Config.ApiScopes)
        .AddInMemoryClients(Config.Clients)
        .AddTestUsers(Config.Users);

builder.Services.AddAuthentication("Bearer")
        .AddJwtBearer("Bearer", options =>
        {
            options.Authority = "https://localhost:5001";
            options.Audience = "api1";
        });

// Additional configuration for ASP.NET Core Identity if needed
builder.Services.AddAuthentication();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddConnectionString(builder.Configuration);

builder.Services.AddPersistenceBuilderServices();
builder.Services.AddApplicationCoreServices();

builder.Services.UseFluentValidation();

builder.Services.AddControllers()
    .UseApiBehaviorOptions();

var app = builder.Build();
app.UseIdentityServer();

// start middleware pipeline
app.UseMiddleware<ExceptionMiddleWare>();
app.Use(async (context, next) =>
{
    using (var scope = app.Services.CreateScope())
    {
        await scope.UseMigrationScope(true);
    }
    await next();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsLocal())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();