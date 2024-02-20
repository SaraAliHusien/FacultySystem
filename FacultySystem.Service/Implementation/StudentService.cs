
using FacultySystem.Data.Enteties;
using FacultySystem.Data.Helpers;
using FacultySystem.Infrastructure.Abstraction;
using FacultySystem.Service.Abstruction;
using FacultySystem.Service.Helpers;
using Microsoft.EntityFrameworkCore;

namespace FacultySystem.Service.Implementation
{
    internal class StudentService : IStudentService
    {
        #region fields
        private readonly IStudentRepo _studentRepo;
        #endregion
        #region ctors
        public StudentService(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }
        #endregion
        #region Implementation methods
        public async Task<List<Student>> GetAllAsync()
        {
            return await _studentRepo.GetAllAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return _studentRepo.GetTableNoTracking().Include(s => s.Department).Where(s => s.StudentId == id).FirstOrDefault();

        }

        public async Task<Student> GetByIdWithoutDeptAsync(int id)
        {
            return _studentRepo.GetTableNoTracking().Where(s => s.StudentId == id).FirstOrDefault();
        }

        public async Task<string> CreateNewStudent(Student newStudent)
        {
            await _studentRepo.AddAsync(newStudent);

            return "Added successfully";
        }
        public async Task<bool> IsUnique(string studentName)
        {
            var name = await _studentRepo.GetTableNoTracking().Where(st => st.StudentName.Equals(studentName)).FirstOrDefaultAsync();
            if (name is null)
                return true;
            return false;
        }

        public async Task<bool> IsUnique(string studentName, int StudentId)
        {
            var name = await _studentRepo.GetTableNoTracking().Where(st => st.StudentName.Equals(studentName) && st.StudentId != StudentId).FirstOrDefaultAsync();
            if (name is null)
                return true;

            return false;
        }

        public async Task<string> EditAsync(Student student)
        {
            await _studentRepo.UpdateAsync(student);
            return "success";
        }

        public async Task<string> DeleteAsync(Student student)
        {
            try
            {
                await _studentRepo.DeleteAsync(student);

            }
            catch (Exception e)
            {
                return ResponseTypesMatching.FailExcuteService;
            }
            return ResponseTypesMatching.DeletedResponse;

        }

        public IQueryable<Student> GetStudentQuarable(StudentOrderingEnum ordering, string search = null)
        {
            var students = _studentRepo.GetTableNoTracking().Include(s => s.Department).AsQueryable();
            if (search is not null)
            {
                students = students.Where(s => s.StudentName.Contains(search) || s.Address.Contains(search)).AsQueryable();
            }
            //CultureInfo culture = Thread.CurrentThread.CurrentCulture;

            switch (ordering)
            {
                case StudentOrderingEnum.id:
                    students = students.OrderBy(s => s.StudentId);
                    break;
                case StudentOrderingEnum.name:

                    students = students.OrderBy(s => s.StudentName);
                    break;
                case StudentOrderingEnum.address:

                    students = students.OrderBy(s => s.Address);
                    break;
                case StudentOrderingEnum.deptName:

                    students = students.OrderBy(s => s.Department.DepartmentName);

                    break;

                default:
                    students = students.OrderBy(s => s.StudentId);
                    break;
            }

            return students;
        }





        #endregion
    }
}
