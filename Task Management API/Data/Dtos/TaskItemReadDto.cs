using Task_Management_API.Data.Models;

namespace Task_Management_API.Data.Dtos
{
    public class TaskItemReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public string UserId { get; set; }
        public string UserName { get; set; } 
        public string ImageBase64 { get; set; }

        internal static async Task<List<TaskItemReadDto>> FromResult(List<TaskItem> taskItems)
        {
            throw new NotImplementedException();
        }
    }
}
