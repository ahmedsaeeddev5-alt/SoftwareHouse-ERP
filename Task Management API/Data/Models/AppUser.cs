using Microsoft.AspNetCore.Identity;

namespace Task_Management_API.Data.Models
{
    public class AppUser : IdentityUser
    {
        public virtual ICollection<TaskItem> TaskItems { get; set; } = new List<TaskItem>();
        public virtual Employee? Employee { get; set; }
    }


}
