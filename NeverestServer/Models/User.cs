using System.ComponentModel.DataAnnotations;

namespace NeverestServer.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Character? Character { get; set; }
    }
}
