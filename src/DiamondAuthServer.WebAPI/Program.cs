using DiamondAuthServer.Persistence;
using DiamondAuthServer.WebAPI.Extensions;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureAppConfiguration(c => c.BuildConfiguration(args));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddConnectionString(builder.Configuration);

builder.Services.AddPersistenceBuilderServices();


var app = builder.Build();

app.Use(async (context, next) =>
{
    using (var scope = app.Services.CreateScope())
    {
        /*var configuration = builder.Configuration;
        var value=configuration.GetSection("RootConfiguration")["MigrationPath"];*/
        await scope.UseMigrationScope();
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