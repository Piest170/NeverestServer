namespace NeverestServer.Data.Dtos.Character
{
    public class UpdateCharacterDto
    {
        public int CharacterId { get; set; }
        public string? CharacterName { get; set; }
        public int JobId { get; set; }
        public int SkillId { get; set; }
        public int QuestId { get; set; }
    }
}
