using NeverestServer.Data.Dtos.Advisor;
using NeverestServer.Data.Dtos.Job;
using NeverestServer.Data.Dtos.Quest;
using NeverestServer.Data.Dtos.Skill;

namespace NeverestServer.Data.Dtos.Character
{
    public class GetCharacterDto
    {
        public int CharacterId { get; set; }
        public string? CharacterName { get; set; }
        public string? JobName { get; set; }
        public List<SkillDto> Skills { get; set; }
        public List<QuestDto> Quests { get; set; }
    }
}
