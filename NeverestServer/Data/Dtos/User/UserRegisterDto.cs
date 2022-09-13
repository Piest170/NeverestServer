using System.ComponentModel.DataAnnotations;

namespace NeverestServer.Data.Dtos.User
{
    public class UserRegisterDto
    {
        [Required(ErrorMessage = "Email Required"), EmailAddress(ErrorMessage = "Your Email cannot use")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Username Required"), StringLength(25)]
        public string Username { get; set; } = string.Empty;
        [Required, MinLength(6)]
        public string Password { get; set; } = string.Empty;
        [Required, Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
