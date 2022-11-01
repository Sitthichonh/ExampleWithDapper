using System.Data;
using System.Data.SqlClient;

namespace ExampleWithDapper.ConnectionContext
{
    public class SqlConnectionContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _sqlConnectionString;
        private readonly string _sqlConnectionStringThaipost;
        public SqlConnectionContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _sqlConnectionString = _configuration.GetConnectionString("SqlConnectionStrings");
            _sqlConnectionStringThaipost = _configuration.GetConnectionString("SqlConnectionStringsThaipost");
        }
        public IDbConnection CreateSqlConnection() => new SqlConnection(_sqlConnectionString);
        public IDbConnection CreateSqlConnectionThaipost() => new SqlConnection(_sqlConnectionStringThaipost);
    }
}
