using System.ComponentModel.DataAnnotations.Schema;

namespace Task_Management_API.Data.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        [ForeignKey(nameof(UserId))]
        public string UserId { get; set; }
        public virtual AppUser User { get; set; }
        public byte[]? Image { get; set; }
    }
}
