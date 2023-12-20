using DiamondAuthServer.ApplicationCore.Commands;
using DiamondAuthServer.ApplicationCore.Ports.Out.IServices;
using DiamondAuthServer.ApplicationCore.Queries;
using DiamondAuthServer.ApplicationCore.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DiamondAuthServer.ApplicationCore
{
    public static class ApplicationCoreBuilder
    {
        public static IServiceCollection AddApplicationCoreServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationCoreBuilder).Assembly));
            services.AddAutoMapper(typeof(ApplicationCoreBuilder));
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();
            services.AddScoped<IQueryDispatcher, QueryDispatcher>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}