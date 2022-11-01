using ExampleWithDapper.Models;

namespace ExampleWithDapper.Interfaces
{
    public interface IStudent
    {
        public Task<IEnumerable<StudentModel>> GetStudentAll();
        public Task<StudentModel> GetStudentByIdAsync(int StudentId);
        public Task InsertStudentByIdAsync(RequestStudentModel model);
        public Task UpdateStudentByIdAsync(int StudentId, RequestStudentModel model);
        public Task DeleteStudentByIdAsync(int StudentId);
    }
}
