using Microsoft.EntityFrameworkCore;
using Task_Management_API.Data;
using Task_Management_API.Data.Models;

namespace Task_Management_API.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _db;

        public ProjectRepository(AppDbContext appDb)
        {
            _db = appDb;
        }
        public async Task<bool> DeleteProjectAsync(int id)
        {
            var project = await _db.Projects.FindAsync(id);

            if (project == null)
                return false;

            _db.Projects.Remove(project);

            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<Project?> GetProjectAsync(int id)
        {
            return await _db.Projects
               .Include(p => p.Client)
               .Include(p => p.ProjectMembers)
               .Include(p => p.Tasks)
               .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Project?> GetProjectDetailsAsync(int id)
        {
            return await _db.Projects
         .Include(p => p.Client)

         .Include(p => p.ProjectMembers)
             .ThenInclude(pm => pm.Employee)

         .Include(p => p.Tasks)
             .ThenInclude(t => t.Employee)

         .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Project>> GetProjectsAsync()
        {
            return await _db.Projects
                 .Include(p => p.Client)
                 .Include(p => p.ProjectMembers)
                 .Include(p => p.Tasks)
                 .ToListAsync();
        }

        public async Task<Project> InsertProjectAsync(Project project)
        {
            await _db.Projects.AddAsync(project);
            await _db.SaveChangesAsync();

            return project;
        }

        public async Task<bool> UpdateProjectAsync(Project project)
        {
            _db.Projects.Update(project);

            return await _db.SaveChangesAsync() > 0;
        }
    }
}
