using System.ComponentModel.DataAnnotations;

namespace Task_Management_API.Data.Dtos
{
    public class dtoLogin
    {
        [Required]
        public string userName { get; set; }
        [Required]
        public string password { get; set; }
    }



}
