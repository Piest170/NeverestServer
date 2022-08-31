namespace NeverestServer.Data.Dtos.Skill
{
    public class SkillDto
    {
        public int SkillId { get; set; }
        public string? SkillName { get; set; }
        public string? SkillGroup { get; set; }
        public int SkillLevel { get; set; }
        public int MaxSkillLevel { get; set; }
    }
}
