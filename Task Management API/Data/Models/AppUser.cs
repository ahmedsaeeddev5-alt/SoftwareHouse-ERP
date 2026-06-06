using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Task_Management_API.Data.Models
{
    public class AppUser : IdentityUser
    {
        public virtual ICollection<TaskItem> TaskItems { get; set; } = new List<TaskItem>();
    }


}
