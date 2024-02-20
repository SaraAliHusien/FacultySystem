using FacultySystem.Data.Enteties;
using FacultySystem.Infrastructure.Abstraction;
using FacultySystem.Service.Abstruction;
using FacultySystem.Service.Helpers;
using Microsoft.EntityFrameworkCore;

namespace FacultySystem.Service.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        #region Fields
        private readonly IDepartmentRepo _departmentRepo;
        private readonly IInstructorService _instructorService;
        #endregion

        #region Ctors
        public DepartmentService(IDepartmentRepo departmentRepo, IInstructorService instructorService)
        {
            _departmentRepo = departmentRepo;
            _instructorService = instructorService;
        }
        #endregion

        #region Actions
        public async Task<Department> GetByIdAsync(int id)
        {
            var department = await _departmentRepo.GetTableNoTracking()
                .Where(d => d.DepartmentId == id)
                .Include(d => d.Students)
                .Include(d => d.Subjects).ThenInclude(s => s.Subject)
                .Include(d => d.InstructorManager)
                .Include(d => d.Instructors).FirstOrDefaultAsync();
            return department;
        }
        public async Task<Department> GetByIdWithoutIncludingAsync(int id)
        {
            return await _departmentRepo.GetByIdAsync(id);
        }

        public async Task<string> CreateNewDeppartment(Department newDept)
        {

            if (newDept.ManagerId <= 0)
                return ResponseTypesMatching.BadRequestResponse;
            var instructor = await _instructorService.GetByIdAsync(newDept.ManagerId.Value);
            if (instructor is null)
                return ResponseTypesMatching.FailFoundFK;
            await _departmentRepo.AddAsync(newDept);
            return ResponseTypesMatching.CreatedResponse;
        }

        public async Task<string> DeleteAsync(Department department)
        {
            try
            {
                await _departmentRepo.DeleteAsync(department);

            }
            catch (Exception e)
            {
                return ResponseTypesMatching.FailExcuteService;
            }
            return ResponseTypesMatching.DeletedResponse;
        }

        public async Task<string> EditAsync(Department department)
        {

            await _departmentRepo.UpdateAsync(department);
            return ResponseTypesMatching.UpdatedResponse;
        }

        public async Task<List<Department>> GetAllAsync()
        {
            var departments = await _departmentRepo.GetTableNoTracking().Include(d => d.InstructorManager).Include(d => d.Students).Include(d => d.Subjects).Include(d => d.Instructors).ToListAsync();

            return departments;
        }



        public async Task<bool> IsUnique(string DeptName)
        {
            var department = await _departmentRepo.GetTableNoTracking().Where(d => d.DepartmentName.Equals(DeptName)).FirstOrDefaultAsync();
            if (department is null) return true;
            return false;

        }

        public async Task<bool> IsUnique(string DeptName, int DeptId)
        {
            var department = await _departmentRepo.GetTableNoTracking().Where(d => d.DepartmentName.Equals(DeptName) && d.DepartmentId != DeptId).FirstOrDefaultAsync();
            if (department is null) return true;
            return false;
        }
        #endregion

    }
}
