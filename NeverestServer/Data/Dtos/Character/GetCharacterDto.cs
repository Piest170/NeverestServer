﻿using NeverestServer.Data.Dtos.Advisor;
using NeverestServer.Data.Dtos.Job;
using NeverestServer.Data.Dtos.Quest;
using NeverestServer.Data.Dtos.Skill;

namespace NeverestServer.Data.Dtos.Character
{
    public class GetCharacterDto
    {
        public int CharacterId { get; set; }
        public string? CharacterName { get; set; }
        public GetAdvisorDto Advisor { get; set; }
        public int JobId { get; set; } = 1;
        public int LearningLevel { get; set; } = 0;
        public string LearningStatus { get; set; } = "Learning";
        public virtual JobDto? Job { get; set; }
        public List<SkillDto> Skills { get; set; }
        public List<QuestDto> Quests { get; set; }
    }
}
