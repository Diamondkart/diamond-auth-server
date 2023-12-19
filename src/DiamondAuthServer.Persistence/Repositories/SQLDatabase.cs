using DiamondAuthServer.Persistence.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DiamondAuthServer.Persistence.Repositories
{
    public class SQLDatabase : ISQLDatabase
    {
        private readonly IConfiguration _configuration;

        public SQLDatabase(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }

        private string GetConnectionString()
        {
            var sqlConnection = new SqlConnectionStringBuilder
            {
                TrustServerCertificate = true
            };
            return sqlConnection.ConnectionString;
        }
    }
}