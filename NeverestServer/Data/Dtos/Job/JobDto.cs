using NeverestServer.Data.Dtos.Skill;

namespace NeverestServer.Data.Dtos.Job
{
    public class JobDto
    {
        public int JobId { get; set; }
        public string JobName { get; set; } = null!;
        public int PrevJobId { get; set; }
        public List<SkillDto> Skills { get; set; }
    }
}
