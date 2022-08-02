using System.ComponentModel.DataAnnotations;

namespace NeverestServer.Models
{
    public class Job
    {
        [Required]
        public int JobId { get; set; }
        public string? JobName { get; set; }
        public int PrevJobId { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
