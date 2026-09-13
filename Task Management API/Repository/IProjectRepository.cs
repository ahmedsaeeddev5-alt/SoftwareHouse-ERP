using Task_Management_API.Data.Models;

namespace Task_Management_API.Repository
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetProjectsAsync();

        Task<Project?> GetProjectAsync(int id);
        Task<Project?> GetProjectDetailsAsync(int id);

        Task<Project> InsertProjectAsync(Project project);

        Task<bool> UpdateProjectAsync(Project project);

        Task<bool> DeleteProjectAsync(int id);
    }
}
