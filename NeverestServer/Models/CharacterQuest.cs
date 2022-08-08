namespace NeverestServer.Models
{
    public class CharacterQuest
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public int QuestId { get; set; }
        public Character Character { get; set; }
        public Quest Quest { get; set; }

    }
}
