namespace NeverestServer.Models
{
    public class Advisor
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? AdvisorName { get; set; }
        public User? User { get; set; }
        public DateTime DataCreated { get; set; } = DateTime.Now;
    }
}
