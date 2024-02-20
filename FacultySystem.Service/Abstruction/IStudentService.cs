using FacultySystem.Data.Enteties;
using FacultySystem.Data.Helpers;

namespace FacultySystem.Service.Abstruction
{
    public interface IStudentService
    {
        public Task<List<Student>> GetAllAsync();
        public Task<Student> GetByIdAsync(int id);
        Task<Student> GetByIdWithoutDeptAsync(int id);
        public Task<string> CreateNewStudent(Student newStudent);
        public Task<bool> IsUnique(string studentName);
        public Task<bool> IsUnique(string studentName, int StudentId);
        Task<string> EditAsync(Student student);
        Task<string> DeleteAsync(Student student);
        IQueryable<Student> GetStudentQuarable(StudentOrderingEnum ordering, string search);


    }
}
