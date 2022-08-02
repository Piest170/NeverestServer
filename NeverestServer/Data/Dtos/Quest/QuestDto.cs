namespace NeverestServer.Data.Dtos.Quest
{
    public class QuestDto
    {
        public int QuestId { get; set; }
        public string? QuestName { get; set; }
        public string? QuestDescription { get; set; }
        public DateTime QuestRecieved { get; set; }
        public DateTime QuestFinished { get; set; }
    }
}
