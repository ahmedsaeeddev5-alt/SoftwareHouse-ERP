using Task_Management_API.Data.Models;

namespace Task_Management_API.Repository
{
    public interface ITaskRepository
    {
        Task<List<TaskItem>> GetItemsAsync();
        Task<TaskItem> GetItemAsync(int id);
        Task<TaskItem> InsertItemAsync(TaskItem item);
        Task<bool> UpdateItemAsync(TaskItem item);
        Task<bool> DeleteItemAsync(int id);
    }
}
