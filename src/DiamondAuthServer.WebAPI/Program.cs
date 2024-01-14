using DiamondAuthServer.ApplicationCore;
using DiamondAuthServer.ApplicationCore.Services;
using DiamondAuthServer.Domain.Exceptions;
using DiamondAuthServer.Persistence;
using DiamondAuthServer.WebAPI.Extensions;

// start building configuration, host, etc ..
var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureAppConfiguration(c => c.BuildConfiguration(args));

builder.Services.AddIdentityServer()
        .AddDeveloperSigningCredential()
        .AddInMemoryApiScopes(AuthConfig.ApiScopes)
        .AddInMemoryApiResources(AuthConfig.ApiResources)
        .AddClientStore<CustomClientStore>()
        .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>()
        .AddProfileService<ProfileService>();

builder.Services.AddAuthentication("Bearer")
        .AddJwtBearer("Bearer", options =>
        {
            options.Authority = "https://localhost:8000";
            options.Audience = "https://localhost:8000/resources";
            options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ClockSkew = new TimeSpan(0, 5, 0),
                ValidateLifetime = true,
                RequireSignedTokens = true,
                SaveSigninToken = true,
                ValidateIssuer = true,
                ValidateAudience = false
            };
        });


builder.Services.AddControllers();
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