using FacultySystem.Data.Enteties;
using FacultySystem.Infrastructure.Abstraction;
using FacultySystem.Service.Abstruction;
using FacultySystem.Service.Helpers;
using Microsoft.EntityFrameworkCore;

namespace FacultySystem.Service.Implementation
{
    public class InstructorService : IInstructorService
    {
        #region Fields
        private readonly IInstructorRepo _instructorRepo;
        #endregion

        #region Ctors
        public InstructorService(IInstructorRepo instructorRepo)
        {
            _instructorRepo = instructorRepo;
        }
        #endregion

        #region Actions
        public async Task<string> CreateNewInstructor(Instructor newInst)
        {
            await _instructorRepo.AddAsync(newInst);
            await _instructorRepo.SaveChangesAsync();
            return "Created";
        }

        public async Task<string> DeleteAsync(Instructor instructor)
        {
            try
            {
                await _instructorRepo.DeleteAsync(instructor);

            }
            catch (Exception e)
            {
                return ResponseTypesMatching.FailExcuteService;
            }
            return ResponseTypesMatching.DeletedResponse;
        }

        public async Task<string> EditAsync(Instructor instructor)
        {
            await _instructorRepo.UpdateAsync(instructor);

            return "Updated";
        }

        public async Task<List<Instructor>> GetAllAsync()
        {
            return await _instructorRepo.GetTableNoTracking().Include(ins => ins.Department).Include(ins => ins.Supervisor).ToListAsync();
        }

        public async Task<Instructor> GetByIdAsync(int id)
        {
            return await _instructorRepo.GetTableNoTracking().Where(ins => ins.InstructorId == id).Include(ins => ins.Department).Include(ins => ins.Supervisor).FirstOrDefaultAsync();

        }
        public async Task<Instructor> GetByIdWithoutIncludingAsync(int id)
        {
            return await _instructorRepo.GetByIdAsync(id);

        }
        public async Task<bool> IsUnique(string InstName)
        {
            var instructor = await _instructorRepo.GetTableNoTracking().Where(ins => ins.InstructorName == InstName).FirstOrDefaultAsync();
            return instructor is null ? true : false;
        }

        public async Task<bool> IsUnique(string InstName, int InstId)
        {
            var instructor = await _instructorRepo.GetTableNoTracking().Where(ins => ins.InstructorName == InstName && ins.InstructorId != InstId).FirstOrDefaultAsync();
            return instructor is null ? true : false;
        }
        #endregion
    }
}
