namespace NeverestServer.Data.Dtos.Character
{
    public class UpdateCharacterDto
    {
        public int CharacterId { get; set; }
        public string? CharacterName { get; set; }
        public int JobId { get; set; } = 1;
        public int LearningLevel { get; set; } = 0;
        public string LearningStatus { get; set; } = "Learning";
    }
}
