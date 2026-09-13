using Task_Management_API.Data.Models;

namespace Task_Management_API.Repository
{
    public interface IProjectMemberRepository
    {
        Task<List<ProjectMember>> GetMembersAsync(int projectId);

        Task<ProjectMember?> GetMemberAsync(int id);

        Task<ProjectMember> InsertMemberAsync(ProjectMember member);

        Task<bool> UpdateMemberAsync(ProjectMember member);

        Task<bool> DeleteMemberAsync(int id);
    }
}
