using Microsoft.EntityFrameworkCore;
using Task_Management_API.Data;
using Task_Management_API.Data.Models;

namespace Task_Management_API.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private AppDbContext _db;
        public TaskRepository(AppDbContext appDb)
        {
            _db = appDb;

        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var item = await _db.Tasks.FindAsync(id);
            if (item == null) return false;

            _db.Tasks.Remove(item);
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<TaskItem> GetItemAsync(int id)
        {

            return await _db.Tasks
             .Include(x => x.User)
             .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TaskItem>> GetItemsAsync()
        {
            return await _db.Tasks
              .Include(x => x.User)
              .ToListAsync();
        }

        public async Task<TaskItem> InsertItemAsync(TaskItem item)
        {
            await _db.Tasks.AddAsync(item);
            await _db.SaveChangesAsync();
            return item;
        }

        public async Task<bool> UpdateItemAsync(TaskItem item)
        {
            _db.Tasks.Update(item);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
