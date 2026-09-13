using Microsoft.EntityFrameworkCore;
using Task_Management_API.Data;
using Task_Management_API.Data.Models;

namespace Task_Management_API.Repository
{
    public class ProjectMemberRepository : IProjectMemberRepository
    {
        private readonly AppDbContext _db;

        public ProjectMemberRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<bool> DeleteMemberAsync(int id)
        {
            var member = await _db.ProjectMembers.FindAsync(id);

            if (member == null)
                return false;

            _db.ProjectMembers.Remove(member);

            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<ProjectMember?> GetMemberAsync(int id)
        {
            return await _db.ProjectMembers
                 .Include(x => x.Project)
                 .Include(x => x.Employee)
                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ProjectMember>> GetMembersAsync(int projectId)
        {
            return await _db.ProjectMembers
                .Include(x => x.Project)
                .Include(x => x.Employee)
                .Where(x => x.ProjectId == projectId)
                .ToListAsync();
        }

        public async Task<ProjectMember> InsertMemberAsync(ProjectMember member)
        {
            await _db.ProjectMembers.AddAsync(member);
            await _db.SaveChangesAsync();

            return member;
        }

        public async Task<bool> UpdateMemberAsync(ProjectMember member)
        {
            _db.ProjectMembers.Update(member);

            return await _db.SaveChangesAsync() > 0;
        }
    }
}
