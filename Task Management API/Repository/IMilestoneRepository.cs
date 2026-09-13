using Task_Management_API.Data.Models;

namespace Task_Management_API.Repository
{
    public interface IMilestoneRepository
    {
        Task<List<Milestone>> GetMilestonesAsync(int projectId);

        Task<Milestone?> GetMilestoneAsync(int id);

        Task<Milestone> InsertMilestoneAsync(Milestone milestone);

        Task<bool> UpdateMilestoneAsync(Milestone milestone);

        Task<bool> DeleteMilestoneAsync(int id);
    }
}
