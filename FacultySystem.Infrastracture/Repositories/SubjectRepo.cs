using FacultySystem.Data.Enteties;
using FacultySystem.Infrastructure.Abstraction;
using FacultySystem.Infrastructure.ApplicationContext;

namespace FacultySystem.Infrastructure.Repositories
{
    public class SubjectRepo : GenericRepositoryAsync<Subject>, ISubjectRepo
    {
        #region Fields
        #endregion

        #region Ctors
        public SubjectRepo(FacultyDbContext context) : base(context)
        {
        }
        #endregion

        #region Actions
        #endregion

    }
}
