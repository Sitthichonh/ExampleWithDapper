using ExampleWithDapper.Models;

namespace ExampleWithDapper.Interfaces
{
    public interface IRole
    {
        public Task<IEnumerable<RolesModel>> GetRoleAll();
        public Task<RolesModel> GetRoleByIdAsync(int Roleid);
        public Task InsertRoleByIdAsync(RolesModel model);
        public Task UpdateRoleByIdAsync(int Roleid, RolesModel model);
        public Task DeleteRoleByIdAsync(int Roleid);
    }
}
