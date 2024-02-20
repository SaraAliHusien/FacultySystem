using FacultySystem.Data.Enteties;

namespace FacultySystem.Infrastructure.Abstraction
{
    public interface IStudentRepo : IGenericRepositoryAsync<Student>
    {
        public Task<List<Student>> GetAllAsync();
    }
}
