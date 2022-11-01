using Dapper;
using ExampleWithDapper.ConnectionContext;
using ExampleWithDapper.Dto;
using ExampleWithDapper.Interfaces;
using ExampleWithDapper.Models;
using System.Data;

namespace ExampleWithDapper.Repository
{
    public class UserRoleRepository : IUserRoles
    {
        private readonly SqlConnectionContext _sqlConnectionContext;
        public UserRoleRepository(SqlConnectionContext sqlConnectionContext)
        {
            _sqlConnectionContext = sqlConnectionContext;
        }
        public async Task<IEnumerable<UserRolesModel>> GetUserRoleAll()
        {
            string storeProcedure = "SPGetUserRolesAll";
            using (IDbConnection connection = _sqlConnectionContext.CreateSqlConnection())
            {
                var userRoles = await connection.QueryAsync<UserRolesModel>(
                    storeProcedure, 
                    commandType: CommandType.StoredProcedure);
                return userRoles.ToList();
            }
        }

        public async Task<UserRolesModel> GetUserRoleById(int UserId)
        {
            string storeProcedure = "SPGetUserRolesById";
            var parameters = new DynamicParameters();
            parameters.Add("UserID", UserId, DbType.Int32, ParameterDirection.Input);
            using (IDbConnection connection = _sqlConnectionContext.CreateSqlConnection())
            {
                var userRole = await connection.QueryFirstOrDefaultAsync<UserRolesModel>(
                    storeProcedure,
                    parameters,
                    commandType: CommandType.StoredProcedure);
                return userRole;
            }
        }

        public async Task InsertUserRole(UserRoleDto user)
        {
            string storeProcedure = "SPInsertUserRoles";
            var parameters = new DynamicParameters();
            parameters.Add("UserID", user.UserID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("RoleID", user.RoleID, DbType.Int32, ParameterDirection.Input);
            using (IDbConnection connection = _sqlConnectionContext.CreateSqlConnection())
            {
                var resutl = await connection.ExecuteAsync(
                    storeProcedure,
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateUserRole(int UserId, UserRoleDto user)
        {
            string storeProcedure = "SPUpdateUserRoles";
            var parameters = new DynamicParameters();
            parameters.Add("UserID", UserId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("RoleID", user.RoleID, DbType.Int32, ParameterDirection.Input);
            using (IDbConnection connection = _sqlConnectionContext.CreateSqlConnection())
            {
                var resutl = await connection.ExecuteAsync(
                    storeProcedure,
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteUserRoleByUserId(int UserId)
        {
            string storeProcedure = "SPDeleteUserRoles";
            var parameters = new DynamicParameters();
            parameters.Add("UserID", UserId, DbType.Int32, ParameterDirection.Input);
            using (IDbConnection connection = _sqlConnectionContext.CreateSqlConnection())
            {
                var resutl = await connection.ExecuteAsync(
                    storeProcedure,
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

    }
}
