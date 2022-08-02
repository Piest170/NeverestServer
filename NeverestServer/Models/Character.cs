namespace NeverestServer.Models
{
    public class Character
    {
        public int CharacterId { get; set; }
        public string? CharacterName { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public Advisor Advisor { get; set; }
        public Job? Job { get; set; }
        //public List<Skill> Skills { get; set; }
        public List<CharacterSkill> CharacterSkills { get; set; }
        //public List<Quest> Quests { get; set; }
        public DateTime DataCreated { get; set; } = DateTime.Now;
    }
}
