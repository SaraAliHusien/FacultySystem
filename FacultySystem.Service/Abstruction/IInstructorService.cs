using FacultySystem.Data.Enteties;

namespace FacultySystem.Service.Abstruction
{
    public interface IInstructorService
    {
        public Task<List<Instructor>> GetAllAsync();
        public Task<Instructor> GetByIdAsync(int id);
        public Task<Instructor> GetByIdWithoutIncludingAsync(int id);

        public Task<string> CreateNewInstructor(Instructor newInst);
        public Task<bool> IsUnique(string InstName);
        public Task<bool> IsUnique(string InstName, int InstId);
        public Task<string> EditAsync(Instructor instructor);
        Task<string> DeleteAsync(Instructor instructor);
    }
}
