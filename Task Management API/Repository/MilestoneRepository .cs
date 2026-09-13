using Microsoft.EntityFrameworkCore;
using Task_Management_API.Data;
using Task_Management_API.Data.Models;

namespace Task_Management_API.Repository
{
    public class MilestoneRepository : IMilestoneRepository
    {
        private readonly AppDbContext _db;

        public MilestoneRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<bool> DeleteMilestoneAsync(int id)
        {
            var milestone =
               await _db.Milestones.FindAsync(id);

            if (milestone == null)
                return false;

            _db.Milestones.Remove(milestone);

            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<Milestone?> GetMilestoneAsync(int id)
        {
            return await _db.Milestones
              .Include(m => m.Project)
              .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Milestone>> GetMilestonesAsync(int projectId)
        {
            return await _db.Milestones
               .Include(m => m.Project)
               .Where(m => m.ProjectId == projectId)
               .ToListAsync();
        }

        public async Task<Milestone> InsertMilestoneAsync(Milestone milestone)
        {
            await _db.Milestones.AddAsync(milestone);

            await _db.SaveChangesAsync();

            return milestone;
        }

        public async Task<bool> UpdateMilestoneAsync(Milestone milestone)
        {
            _db.Milestones.Update(milestone);

            return await _db.SaveChangesAsync() > 0;
        }
    }
}
