using System.ComponentModel.DataAnnotations;

namespace Task_Management_API.Data.Dtos
{
    public class dtoNewUser
    {
        [Required]
        public string userName { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string email { get; set; }
        public string? PhoneNumber { get; set; }

    }


}
