using System.ComponentModel.DataAnnotations;

namespace MyApplication.Server.Models.Identity
{
    public class LoginUserModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
