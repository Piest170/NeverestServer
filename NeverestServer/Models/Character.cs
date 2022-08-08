namespace NeverestServer.Models
{
    public class Character
    {
        public int CharacterId { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int JobId { get; set; }
        public Job? Job { get; set; }
        public int CharacterSkillsId { get; set; }
        public List<CharacterSkill> CharacterSkills { get; set; }
        public int CharacterQuestsId { get; set; }
        public List<CharacterQuest> CharacterQuests { get; set; }
        public DateTime DataCreated { get; set; } = DateTime.Now;
        public DateTime DataUpdated { get; set; }
    }
}
