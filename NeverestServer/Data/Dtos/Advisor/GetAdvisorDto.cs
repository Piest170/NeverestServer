using NeverestServer.Data.Dtos.Character;
using NeverestServer.Data.Dtos.Job;
using NeverestServer.Data.Dtos.Skill;

namespace NeverestServer.Data.Dtos.Advisor
{
    public class GetAdvisorDto
    {
        public int AdvisorId { get; set; }
        public string? AdvisorName { get; set; }
        public JobDto? jobDto { get; set; }
        public List<SkillDto> Skills { get; set; }
        public List<GetCharacterDto> Characters { get; set; }
    }
}
