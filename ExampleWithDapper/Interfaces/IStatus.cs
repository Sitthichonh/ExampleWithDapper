using ExampleWithDapper.Models;

namespace ExampleWithDapper.Interfaces
{
    public interface IStatus
    {
        Task<StatusModel> GetStatusById(int StatusId);
    }
}
