namespace NeverestServer.Data.Dtos.Advisor
{
    public class GetCharacterSkillForAdvisorDto
    {
        public int Id { get; set; }
        public string? CharacterName { get; set; }
        public string? SkillName { get; set; }
        public int LearningLevel { get; set; }
        public string? LearningStatus { get; set; }
    }
}
