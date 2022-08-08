using System.ComponentModel.DataAnnotations;

namespace NeverestServer.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } 
        public byte[] PasswordSalt { get; set; } 
        public string? Token { get; set; }
        public DateTime? VerifiedTime { get; set; }
        public string? ResetPasswordToken { get; set; }
        public DateTime? TokenExpired { get; set; }
        public Character? Character { get; set; }
        public Advisor? Advisor { get; set; }
    }
}
