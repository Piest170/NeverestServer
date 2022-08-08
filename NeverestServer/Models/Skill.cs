using System.ComponentModel.DataAnnotations;

namespace NeverestServer.Models
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string? SkillName { get; set; }
        public string? SkillGroup { get; set; }
        public int MaxSkillLevel { get; set; }
        public List<CharacterSkill> CharacterSkills { get; set; }
        public List<JobSkill> JobSkills { get; set; }

    }
}
