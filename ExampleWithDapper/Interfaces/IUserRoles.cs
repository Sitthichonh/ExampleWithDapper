using ExampleWithDapper.Dto;
using ExampleWithDapper.Models;

namespace ExampleWithDapper.Interfaces
{
    public interface IUserRoles
    {
        Task<IEnumerable<UserRolesModel>> GetUserRoleAll();
        Task<UserRolesModel> GetUserRoleById(int UserId);
        Task InsertUserRole(UserRoleDto user);
        Task UpdateUserRole(int UserId, UserRoleDto user);
        Task DeleteUserRoleByUserId(int UserId);
    }
}
