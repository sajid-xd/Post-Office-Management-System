using System.ComponentModel.DataAnnotations;

namespace Post_Office_Management.Models
{
    public class Login
    {
        [Key]
        public string email { get; set; }
        public string password { get; set; }
    }
}
