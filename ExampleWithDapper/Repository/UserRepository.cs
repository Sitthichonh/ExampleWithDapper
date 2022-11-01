using Dapper;
using ExampleWithDapper.ConnectionContext;
using ExampleWithDapper.Interfaces;
using ExampleWithDapper.Models;
using System.Data;

namespace ExampleWithDapper.Repository
{
    public class UserRepository : IUser
    {
        private readonly SqlConnectionContext _sqlConnectionContext;
        public UserRepository(SqlConnectionContext sqlConnectionContext)
        {
            _sqlConnectionContext = sqlConnectionContext;
        }
      
        public async Task<IEnumerable<UsersModel>> GetUserAll()
        {
            string storeProcedure = "SPGetUserAll";
            using (IDbConnection connection = _sqlConnectionContext.CreateSqlConnection())
            {
                var user = await connection.QueryAsync<UsersModel>(storeProcedure, commandType: CommandType.StoredProcedure);
                return user.ToList();
            }
        }

        public async Task<UsersModel> GetUserByIdAsync(int Userid)
        {
            string storeProcedure = "SPGetUserById";
            var parameters = new DynamicParameters();
            parameters.Add("UserID", Userid, DbType.Int32, ParameterDirection.Input);
            using (IDbConnection connection = _sqlConnectionContext.CreateSqlConnection())
            {
                var user = await connection.QueryFirstOrDefaultAsync<UsersModel>(
                    storeProcedure, 
                    parameters, 
                    commandType: CommandType.StoredProcedure);
                return user;
            }
        }

        public async Task<UsersModel> GetUserByNameAsync(string username, string password)
        {
            string storeProcedure = "SPGetUserByName";
            var parameters = new DynamicParameters();
            parameters.Add("Username", username, DbType.String, ParameterDirection.Input);
            parameters.Add("Password", password, DbType.String, ParameterDirection.Input);
            using (IDbConnection connection = _sqlConnectionContext.CreateSqlConnection())
            {
                var user = await connection.QueryFirstOrDefaultAsync<UsersModel>(
                    storeProcedure, 
                    parameters, 
                    commandType: CommandType.StoredProcedure);
                return user;
            }
        }

        public async Task<UsersModel> InsertUserByIdAsync(RequestUserModel user)
        {
            string storeProcedure = "SPInsertUser";
            var parameters = new DynamicParameters();
            parameters.Add("Username", user.Username, DbType.String, ParameterDirection.Input);
            parameters.Add("Email", user.Email, DbType.String, ParameterDirection.Input);
            parameters.Add("Password", user.Password, DbType.String, ParameterDirection.Input);
            parameters.Add("StatusID", user.StatusID, DbType.Int32, ParameterDirection.Input);
            using (IDbConnection connection = _sqlConnectionContext.CreateSqlConnection())
            {
                var id = await connection.QuerySingleAsync<int>(storeProcedure, 
                    parameters, 
                    commandType: CommandType.StoredProcedure);
                var userDto = new UsersModel()
                {
                    UserID = id,
                    Username = user.Username,
                    Email = user.Email,
                    Password = user.Password,
                    StatusID = user.StatusID
                };
                return userDto;
            }
        }
        
        public async Task UpdateUserByIdAsync(int Userid, RequestUserModel user)
        {
            {
                string storeProcedure = "SPUpdateUser";
                var parameters = new DynamicParameters();
                parameters.Add("UserID", Userid, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Username", user.Username, DbType.String, ParameterDirection.Input);
                parameters.Add("Email", user.Email, DbType.String, ParameterDirection.Input);
                parameters.Add("Password", user.Password, DbType.String, ParameterDirection.Input);
                parameters.Add("StatusID", user.StatusID, DbType.Int32, ParameterDirection.Input);
                using (IDbConnection connection = _sqlConnectionContext.CreateSqlConnection())
                {
                    var resutl = await connection.ExecuteAsync(
                        storeProcedure, 
                        parameters, 
                        commandType: CommandType.StoredProcedure);
                }
            }
        }

        public async Task DeleteUserByIdAsync(int Userid)
        {
            string storeProcedure = "SPDeleteUser";
            var parameter = new DynamicParameters();
            parameter.Add("UserID", Userid, DbType.Int32, ParameterDirection.Input);
            using (IDbConnection connection = _sqlConnectionContext.CreateSqlConnection())
            {
                await connection.ExecuteAsync(storeProcedure, parameter, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
