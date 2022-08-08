using System.ComponentModel.DataAnnotations;

namespace NeverestServer.Models
{
    public class Quest
    {
        public int QuestId { get; set; }
        public string? QuestName { get; set; }
        public string? QuestDescription { get; set; }
        public DateTime QuestRecieved { get; set; }
        public DateTime QuestFinished { get; set; }
        public List<CharacterQuest> CharacterQuests { get; set; }
    }
}
