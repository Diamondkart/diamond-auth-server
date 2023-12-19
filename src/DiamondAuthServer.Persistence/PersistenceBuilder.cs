using DiamondAuthServer.ApplicationCore.Ports.Out;
using DiamondAuthServer.Domain.Constants;
using DiamondAuthServer.Persistence.DbMigration.interfaces;
using DiamondAuthServer.Persistence.DbMigration.RootConfigurations;
using DiamondAuthServer.Persistence.DBStorage;
using DiamondAuthServer.Persistence.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
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
            //services.AddScoped<IEvolveMigration, EvolveMigration>();
            services.AddScoped<IAccountRespository, AccountRespository>();
            return services;
        }

        public static IServiceCollection AddConnectionString(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserDBContext>(options => options.UseSqlServer(configuration.GetConnectionString(UserConstants.ConnectionStringName)));
            return services;
        }

        private static IDbConnection GetAuthDBConnection(IConfiguration configuration)
        {
            return new SqlConnection(configuration.GetConnectionString(AuthConstants.ConnectionStringName));
        }

        public static async Task<bool> UseMigrationScope(this IServiceScope scope)
        {
            var serviceProvider = scope.ServiceProvider;
            var rootConfiguration = serviceProvider.GetRequiredService<IRootConfiguration>();
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            var migrationService = serviceProvider.GetRequiredService<IMigration>();
            var migrationPath = configuration.GetSection("RootConfiguration")["MigrationPath"];
            if (await rootConfiguration.ValidMigrationConfigurationPath(configuration))
            {
                return await migrationService.RunMigration(GetAuthDBConnection(configuration), migrationPath);
            }
            return false;
        }
    }
}