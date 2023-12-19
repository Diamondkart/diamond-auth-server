using DiamondAuthServer.Domain.Constants;
using DiamondAuthServer.Persistence.DbMigration.interfaces;
using DiamondAuthServer.Persistence.DbMigration.RootConfigurations;
using DiamondAuthServer.Persistence.DBStorage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserPlatform.Persistence.DbMigration.interfaces;
using UserPlatform.Persistence.DbMigration.migrations;

namespace DiamondAuthServer.Persistence
{
    public static class PersistenceBuilders
    {
        public static IServiceCollection AddPersistenceBuilderServices(this IServiceCollection services)
        {
            services.AddScoped<IMigration, Migration>();
            services.AddScoped<IRootConfiguration, RootConfiguration>();
            services.AddScoped<IEvolveMigration, EvolveMigration>();
            return services;
        }

        public static IServiceCollection AddConnectionString(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserDBContext>(options => options.UseSqlServer(configuration.GetConnectionString(UserConstants.ConnectionStringName)));
            return services;
        }

        public static async Task<bool> UseMigrationScope(this IServiceScope scope)
        {
            var serviceProvider = scope.ServiceProvider;
            var service = serviceProvider.GetRequiredService<IMigration>();
            var rootConfiguration = serviceProvider.GetRequiredService<IRootConfiguration>();
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            if (await rootConfiguration.ValidMigrationConfigurationPath(configuration))
            {
                return await service.RunMigration();
            }
            return false;
        }
    }
}