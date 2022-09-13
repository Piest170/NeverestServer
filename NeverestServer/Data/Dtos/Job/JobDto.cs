using NeverestServer.Data.Dtos.Skill;

namespace NeverestServer.Data.Dtos.Job
{
    public class JobDto
    {
        public int JobId { get; set; }
        public string? JobName { get; set; }
        public int PrevJobId { get; set; }
    }
}
