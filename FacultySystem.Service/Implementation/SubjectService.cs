using FacultySystem.Data.Enteties;
using FacultySystem.Infrastructure.Abstraction;
using FacultySystem.Service.Abstruction;
using FacultySystem.Service.Helpers;
using Microsoft.EntityFrameworkCore;

namespace FacultySystem.Service.Implementation
{
    public class SubjectService : ISubjectService
    {
        #region Fields
        private readonly ISubjectRepo _subjectRepo;

        #endregion

        #region Ctors
        public SubjectService(ISubjectRepo subjectRepo)
        {
            _subjectRepo = subjectRepo;
        }
        #endregion

        #region Actions
        public async Task<string> CreateNewSubject(Subject newSubject)
        {
            await _subjectRepo.AddAsync(newSubject);
            await _subjectRepo.SaveChangesAsync();
            return "Created";
        }

        public async Task<string> DeleteAsync(Subject subject)
        {
            try
            {
                await _subjectRepo.DeleteAsync(subject);

            }
            catch (Exception e)
            {
                return ResponseTypesMatching.FailExcuteService;
            }
            return ResponseTypesMatching.DeletedResponse;
        }

        public async Task<string> EditAsync(Subject subject)
        {
            await _subjectRepo.UpdateAsync(subject);

            return "Updated";
        }

        public async Task<List<Subject>> GetAllAsync()
        {
            return await _subjectRepo.GetTableNoTracking().Include(sub => sub.Departments).Include(sub => sub.Instructors).Include(sub => sub.Students).ToListAsync();
        }


        public async Task<Subject> GetByIdAsync(int id)
        {
            return await _subjectRepo.GetTableNoTracking().Where(sub => sub.SubjectId == id).Include(sub => sub.Departments).Include(sub => sub.Instructors).Include(sub => sub.Students).FirstOrDefaultAsync();

        }
        public async Task<Subject> GetByIdWithoutIncludingAsync(int id)
        {
            return await _subjectRepo.GetByIdAsync(id);

        }
        public async Task<bool> IsUnique(string subName)
        {
            var subject = await _subjectRepo.GetTableNoTracking().Where(sub => sub.SubjectName == subName).FirstOrDefaultAsync();
            return subject is null ? true : false;
        }

        public async Task<bool> IsUnique(string subName, int subId)
        {
            var subject = await _subjectRepo.GetTableNoTracking().Where(sub => sub.SubjectName == subName && sub.SubjectId != subId).FirstOrDefaultAsync();
            return subject is null ? true : false;
        }
        #endregion
    }
}
