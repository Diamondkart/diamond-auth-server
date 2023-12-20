using DiamondAuthServer.ApplicationCore;
using DiamondAuthServer.Domain.Exceptions;
using DiamondAuthServer.Persistence;
using DiamondAuthServer.WebAPI.Extensions;

// start building configuration, host, etc ..
var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureAppConfiguration(c => c.BuildConfiguration(args));

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

app.UseAuthorization();

app.MapControllers();

app.Run();