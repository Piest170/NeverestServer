namespace NeverestServer.Data.Dtos.Character
{
    public class AddCharacterSkillDto
    {
        public int CharacterId { get; set; }
        public int SkillId { get; set; }
        public int LearningLevel { get; set; } = 0;
        public string LearningStatus { get; set; } = string.Empty;
    }
}
