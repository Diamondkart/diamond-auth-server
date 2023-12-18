using DiamondAuthServer.Domain.Constants;
using DiamondAuthServer.Persistence.DBStorage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DiamondAuthServer.Persistence
{
    public static class PersistenceBuilder
    {
        public static IServiceCollection AddPersistenceBuilderServices(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddConnectionString(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserDBContext>(options => options.UseSqlServer(configuration.GetConnectionString(UserConstants.ConnectionStringName)));
            return services;
        }
    }
}