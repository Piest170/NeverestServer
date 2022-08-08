namespace NeverestServer.Models
{
    public class CharacterSkill
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public int SkillId { get; set; }
        public int LearningLevel { get; set; } = 0;
        public string? LearningStatus { get; set; }
        public Character Character { get; set; }
        public Skill Skill { get; set; }
    }
}
