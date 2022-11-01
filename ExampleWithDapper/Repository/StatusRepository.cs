using Dapper;
using ExampleWithDapper.ConnectionContext;
using ExampleWithDapper.Interfaces;
using ExampleWithDapper.Models;
using System.Data;

namespace ExampleWithDapper.Repository
{
    public class StatusRepository : IStatus
    {
        private readonly SqlConnectionContext _sqlConnectionContext;
        public StatusRepository(SqlConnectionContext sqlConnectionContext)
        {
            _sqlConnectionContext = sqlConnectionContext;
        }

        public async Task<StatusModel> GetStatusById(int StatusId)
        {
            string storeProcedure = "SPGetStatusById";
            var parameters = new DynamicParameters();
            parameters.Add("StatusID", StatusId, DbType.Int32, ParameterDirection.Input);
            using (IDbConnection connection = _sqlConnectionContext.CreateSqlConnection())
            {
                var user = await connection.QueryFirstOrDefaultAsync<StatusModel>(storeProcedure, parameters, commandType: CommandType.StoredProcedure);
                return user;
            }
        }
    }
}
