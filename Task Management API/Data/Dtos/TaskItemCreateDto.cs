using Task_Management_API.Data.Models;

namespace Task_Management_API.Data.Dtos
{
    public class TaskItemCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public IFormFile Image { get; set; }

    }
}
