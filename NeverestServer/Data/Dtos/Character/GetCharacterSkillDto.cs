using NeverestServer.Data.Dtos.Skill;

namespace NeverestServer.Data.Dtos.Character
{
    public class GetCharacterSkillDto
    {
        public int Id { get; set; }
        public string? CharacterName { get; set; }
        public string? SkillName { get; set; }
        public int LearningLevel { get; set; }
        public string? LearningStatus { get; set; }
    }
}
