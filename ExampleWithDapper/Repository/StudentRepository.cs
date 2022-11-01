using Dapper;
using ExampleWithDapper.ConnectionContext;
using ExampleWithDapper.Interfaces;
using ExampleWithDapper.Models;
using System.Data;

namespace ExampleWithDapper.Repository
{
    public class StudentRepository : IStudent
    {
        private readonly SqlConnectionContext _sqlConnectionContext;
        public StudentRepository(SqlConnectionContext sqlConnectionContext)
        {
            _sqlConnectionContext = sqlConnectionContext;
        }

        public async Task<IEnumerable<StudentModel>> GetStudentAll()
        {
            string storeProcedure = "SPGetAll";
            using(IDbConnection connection = _sqlConnectionContext.CreateSqlConnection())
            {
                var student = await connection.QueryAsync<StudentModel>(storeProcedure, commandType: CommandType.StoredProcedure);
                return student;
            }
        }

        public async Task<StudentModel> GetStudentByIdAsync(int StudentID)
        {
            string storeProcedure = "SPGetById";
            var parameters = new DynamicParameters();
            parameters.Add("StudentID", StudentID, DbType.Int32, ParameterDirection.Input);
            using (IDbConnection connection = _sqlConnectionContext.CreateSqlConnection())
            {
                var student = await connection.QueryFirstOrDefaultAsync<StudentModel>(storeProcedure,parameters, commandType: CommandType.StoredProcedure);
                return student;
            }
        }

        public async Task InsertStudentByIdAsync(RequestStudentModel model)
        {
            string storeProcedure = "SPInsert";
            var parameters = new DynamicParameters();
            parameters.Add("FirstName", model.FirstName, DbType.String, ParameterDirection.Input);
            parameters.Add("LastName", model.LastName, DbType.String, ParameterDirection.Input);
            parameters.Add("Age", model.Age, DbType.Int32, ParameterDirection.Input);
            parameters.Add("AddressN", model.AddressN, DbType.String, ParameterDirection.Input);
            parameters.Add("BD", model.BD, DbType.String, ParameterDirection.Input);
            using (IDbConnection connection = _sqlConnectionContext.CreateSqlConnection())
            {
                await connection.ExecuteAsync(storeProcedure,parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateStudentByIdAsync(int StudentId,RequestStudentModel model)
        {
            string storeProcedure = "SPUpdate";
            var parameters = new DynamicParameters();
            parameters.Add("StudentID", StudentId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("FirstName", model.FirstName, DbType.String, ParameterDirection.Input);
            parameters.Add("LastName", model.LastName, DbType.String, ParameterDirection.Input);
            parameters.Add("Age", model.Age, DbType.Int32, ParameterDirection.Input);
            parameters.Add("AddressN", model.AddressN, DbType.String, ParameterDirection.Input);
            parameters.Add("BD", model.BD, DbType.String, ParameterDirection.Input);
            using (IDbConnection connection = _sqlConnectionContext.CreateSqlConnection())
            {
                await connection.ExecuteAsync(storeProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task DeleteStudentByIdAsync(int StudentId)
        {
            string storeProcedure = "SPDelete";
            var parameter = new DynamicParameters();
            parameter.Add("StudentID", StudentId, DbType.Int32, ParameterDirection.Input);
            using (IDbConnection connection = _sqlConnectionContext.CreateSqlConnection())
            {
                await connection.ExecuteAsync(storeProcedure, parameter, commandType: CommandType.StoredProcedure);
            }

        }
    }
}
