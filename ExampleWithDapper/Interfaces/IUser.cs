using ExampleWithDapper.Models;

namespace ExampleWithDapper.Interfaces
{
    public interface IUser
    {
        public Task<IEnumerable<UsersModel>> GetUserAll();
        public Task<UsersModel> GetUserByIdAsync(int Userid);
        public Task<UsersModel> GetUserByNameAsync(string username,string password);
        public Task<UsersModel> InsertUserByIdAsync(RequestUserModel user);
        public Task UpdateUserByIdAsync(int Userid, RequestUserModel user);
        public Task DeleteUserByIdAsync(int Userid);
    }
}
