
using FacultySystem.Data.Enteties;
using FacultySystem.Infrastructure.Abstraction;
using FacultySystem.Infrastructure.ApplicationContext;
using FacultySystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Faculty.Infrastructure.Repositories
{
    internal class StudentRepo : GenericRepositoryAsync<Student>, IStudentRepo

    {
        #region Faild

        #endregion
        #region ctors
        public StudentRepo(FacultyDbContext context) : base(context) { }

        #endregion
        #region implementation methods
        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.Students.Include(s => s.Department).ToListAsync();
        }



        #endregion
    }
}
