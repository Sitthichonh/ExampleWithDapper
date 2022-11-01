using ExampleWithDapper.Models;

namespace ExampleWithDapper.Interfaces
{
    public interface IThaipost
    {
        Task<IEnumerable<ThaipostModel>> GetThaipostAll();
        Task<ThaipostModel> GetThaipostByIdAsync(string ZipCode);
        Task InsertThaipostAsync(ThaipostModel thaipost);
        Task UpdateThaipostAsync(string ZipCode, ThaipostModel thaipost);
        Task DeleteThaipostAsync(string ZipCode);
    }
}
