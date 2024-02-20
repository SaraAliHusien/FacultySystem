using FacultySystem.Data.Enteties;

namespace FacultySystem.Service.Abstruction
{
    public interface ISubjectService
    {
        public Task<List<Subject>> GetAllAsync();
        public Task<Subject> GetByIdAsync(int id);
        public Task<Subject> GetByIdWithoutIncludingAsync(int id);

        public Task<string> CreateNewSubject(Subject newSubject);
        public Task<string> EditAsync(Subject subject);
        public Task<string> DeleteAsync(Subject subject);
        public Task<bool> IsUnique(string subName);
        public Task<bool> IsUnique(string subName, int subId);





    }
}
