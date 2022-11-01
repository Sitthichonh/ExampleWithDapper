using Dapper;
using ExampleWithDapper.ConnectionContext;
using ExampleWithDapper.Interfaces;
using ExampleWithDapper.Models;
using System.Data;

namespace ExampleWithDapper.Repository
{
    public class ThaipostRepository : IThaipost
    {
        private readonly SqlConnectionContext _sqlConnectionContext;
        public ThaipostRepository(SqlConnectionContext sqlConnectionContext)
        {
            _sqlConnectionContext = sqlConnectionContext;
        }


        public async Task<IEnumerable<ThaipostModel>> GetThaipostAll()
        {
            string storeProcedure = "SPGetThaipostAll";
            using (IDbConnection connection = _sqlConnectionContext.CreateSqlConnectionThaipost())
            {
                var thaipost = await connection.QueryAsync<ThaipostModel>(
                    storeProcedure, 
                    commandType: CommandType.StoredProcedure);
                return thaipost.ToList();
            }
        }

        public async Task<ThaipostModel> GetThaipostByIdAsync(string ZipCode)
        {
            string storeProcedure = "SPGetThaipostById";
            var parameters = new DynamicParameters();
            parameters.Add("POI_ZIP_CODE", ZipCode, DbType.String, ParameterDirection.Input);
            using (IDbConnection connection = _sqlConnectionContext.CreateSqlConnectionThaipost())
            {
                var thaipost = await connection.QueryFirstOrDefaultAsync<ThaipostModel>(
                    storeProcedure,
                    parameters,
                    commandType: CommandType.StoredProcedure);
                return thaipost;
            }
        }

        public async Task InsertThaipostAsync(ThaipostModel thaipost)
        {
            string storeProcedure = "SPInsertThaipost";
            var parameters = new DynamicParameters();
            parameters.Add("POI_ZIP_CODE", thaipost.ZipCode, DbType.String, ParameterDirection.Input);
            parameters.Add("POI_POST_OFFICE_NAME", thaipost.PostOfficeName, DbType.String, ParameterDirection.Input);
            parameters.Add("POI_BRANCH", thaipost.Branch, DbType.String, ParameterDirection.Input);
            parameters.Add("POI_ADDRESS", thaipost.Address, DbType.String, ParameterDirection.Input);
            parameters.Add("POI_PHONE", thaipost.Phone, DbType.String, ParameterDirection.Input);
            parameters.Add("POI_WORKING_DAY", thaipost.WorkingDay, DbType.String, ParameterDirection.Input);
            using (IDbConnection connection = _sqlConnectionContext.CreateSqlConnectionThaipost())
            {
                    await connection.ExecuteAsync(storeProcedure,
                        parameters,
                        commandType: CommandType.StoredProcedure);
                
            }
        }

        public async Task UpdateThaipostAsync(string ZipCode, ThaipostModel thaipost)
        {
            string storeProcedure = "SPUpdateThaipost";
            var parameters = new DynamicParameters();
            parameters.Add("POI_ZIP_CODE", ZipCode, DbType.String, ParameterDirection.Input);
            parameters.Add("POI_POST_OFFICE_NAME", thaipost.PostOfficeName, DbType.String, ParameterDirection.Input);
            parameters.Add("POI_BRANCH", thaipost.Branch, DbType.String, ParameterDirection.Input);
            parameters.Add("POI_ADDRESS", thaipost.Address, DbType.String, ParameterDirection.Input);
            parameters.Add("POI_PHONE", thaipost.Phone, DbType.String, ParameterDirection.Input);
            parameters.Add("POI_WORKING_DAY", thaipost.WorkingDay, DbType.String, ParameterDirection.Input);
            using (IDbConnection connection = _sqlConnectionContext.CreateSqlConnectionThaipost())
            {
                await connection.ExecuteAsync(storeProcedure,
                    parameters,
                    commandType: CommandType.StoredProcedure);

            }
        }

        public async Task DeleteThaipostAsync(string ZipCode)
        {
            string storeProcedure = "SPDeleteThaipost";
            var parameters = new DynamicParameters();
            parameters.Add("POI_ZIP_CODE", ZipCode, DbType.String, ParameterDirection.Input);
            using (IDbConnection connection = _sqlConnectionContext.CreateSqlConnectionThaipost())
            {
                await connection.ExecuteAsync(storeProcedure, 
                    parameters, 
                    commandType: CommandType.StoredProcedure);
            }
        }

    }
}
