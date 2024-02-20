using FacultySystem.Data.Enteties;

namespace FacultySystem.Service.Abstruction
{
    public interface IDepartmentService
    {
        public Task<List<Department>> GetAllAsync();
        public Task<Department> GetByIdAsync(int id);
        public Task<Department> GetByIdWithoutIncludingAsync(int id);

        public Task<string> CreateNewDeppartment(Department newDept);
        public Task<bool> IsUnique(string DeptName);
        public Task<bool> IsUnique(string DeptName, int DeptId);
        Task<string> EditAsync(Department department);
        Task<string> DeleteAsync(Department department);
        //IQueryable<Student> GetStudentQuarable(StudentOrderingEnum ordering, string search);
    }
}
