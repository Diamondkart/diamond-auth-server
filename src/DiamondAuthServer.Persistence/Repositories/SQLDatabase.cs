using DiamondAuthServer.Domain.Models;
using DiamondAuthServer.Persistence.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
//using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DiamondAuthServer.Persistence.Repositories
{
    public class SQLDatabase : ISQLDatabase
    {
        private readonly IConfiguration _configuration;
        private readonly DatabaseConfig _databaseConfig;

        public SQLDatabase(IConfiguration configuration)
        {
            _configuration = configuration;
            _databaseConfig = _configuration.GetSection("AuthDbConnection").Get<DatabaseConfig>()!;
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }

        private string GetConnectionString()
        {
            var sqlConnection = new SqlConnectionStringBuilder
            {
                
                CommandTimeout=_databaseConfig.CommandTimeOut,
                DataSource=_databaseConfig.Server,
                InitialCatalog=_databaseConfig.Database,
                PersistSecurityInfo=true,
                TrustServerCertificate = true,
                Encrypt=_databaseConfig.Encrypt,
                IntegratedSecurity=true,
                
            };
            return sqlConnection.ConnectionString;
        }
    }
}