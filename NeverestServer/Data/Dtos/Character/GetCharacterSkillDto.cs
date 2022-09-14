namespace NeverestServer.Data.Dtos.Character
{
    public class GetCharacterSkillDto
    {
        public int CharacterId { get; set; }
        public int SkillId { get; set; }
        public int LearningLevel { get; set; } = 0;
    }
}
