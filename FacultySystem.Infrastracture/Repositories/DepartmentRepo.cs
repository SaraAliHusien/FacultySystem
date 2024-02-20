using FacultySystem.Data.Enteties;
using FacultySystem.Infrastructure.Abstraction;
using FacultySystem.Infrastructure.ApplicationContext;

namespace FacultySystem.Infrastructure.Repositories
{
    public class DepartmentRepo : GenericRepositoryAsync<Department>, IDepartmentRepo
    {
        #region Fields
        #endregion

        #region Ctors
        public DepartmentRepo(FacultyDbContext context) : base(context)
        {
        }
        #endregion

        #region Actions
        #endregion

    }
}
