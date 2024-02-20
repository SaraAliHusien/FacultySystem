using FacultySystem.Data.Enteties;
using FacultySystem.Infrastructure.Abstraction;
using FacultySystem.Infrastructure.ApplicationContext;

namespace FacultySystem.Infrastructure.Repositories
{
    public class InstructorRepo : GenericRepositoryAsync<Instructor>, IInstructorRepo
    {
        #region Fields
        #endregion

        #region Ctors
        public InstructorRepo(FacultyDbContext context) : base(context)
        {
        }
        #endregion

        #region Actions
        #endregion

    }
}
