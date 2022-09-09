using Microsoft.EntityFrameworkCore;
using NeverestServer.Data.Dtos.Advisor;
using NeverestServer.Data.Dtos.Character;
using NeverestServer.Data.Dtos.Skill;
using NeverestServer.Models;
using System.Security.Claims;

namespace NeverestServer.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CharacterService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User
            .FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var response = new ServiceResponse<List<GetCharacterDto>>();
            var db = await _context.Characters
                .Include(c => c.User)
                .Include(c => c.Job)
                .Include(c => c.CharacterSkills).ThenInclude(cs => cs.Skill)
                //.Where(c => c.User.Id == GetUserId())
                .Select(c => new GetCharacterDto()
                {
                    CharacterId = c.CharacterId,
                    CharacterName = c.User.Username,
                    JobId = c.Job.JobId,
                    Skills = c.CharacterSkills.Select(
                        cs => new SkillDto()
                        {
                            SkillId = cs.SkillId,
                            SkillName = cs.Skill.SkillName,
                            SkillGroup = cs.Skill.SkillGroup,
                            SkillLevel = cs.LearningLevel,
                            MaxSkillLevel = cs.Skill.MaxSkillLevel
                        }).ToList()
                })
                .ToListAsync();
            if (db == null)
            {
                response.Success = false;
                response.Message = "No Any Character";
            }
            else
            {
                response.Data = db;
                response.Success = true;
                response.Message = "Get Character List";
            }
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacter(int id)
        {
            var response = new ServiceResponse<GetCharacterDto>();
            var db = await _context.Characters
                .Include(c => c.User)
                .Include(c => c.Job)
                .Include(c => c.CharacterSkills).ThenInclude(cs => cs.Skill)
                .Select(c => new GetCharacterDto()
                {
                    CharacterId = c.CharacterId,
                    CharacterName = c.User.Username,
                    JobId = c.Job.JobId,
                    Skills = c.CharacterSkills.Select(
                        cs => new SkillDto()
                        {
                            SkillId = cs.SkillId,
                            SkillName = cs.Skill.SkillName,
                            SkillGroup = cs.Skill.SkillGroup,
                            SkillLevel = cs.LearningLevel,
                            MaxSkillLevel = cs.Skill.MaxSkillLevel
                        }).ToList()
                }).FirstOrDefaultAsync(c => c.CharacterId == id);
            if (db == null)
            {
                response.Success = false;
                response.Message = "Not Found Character";
            }
            else
            {
                response.Data = db;
                response.Success = true;
                response.Message = "Found Character";
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetCharacterSkillDto>>> GetAllCharacterSkills()
        {
            var response = new ServiceResponse<List<GetCharacterSkillDto>>();
            var db = await _context.CharacterSkills
                .Include(cs => cs.Character).ThenInclude(cs => cs.User)
                .Select(c => new GetCharacterSkillDto()
                {
                    Id = c.Id,
                    CharacterName = c.Character.User.Username,
                    SkillName = c.Skill.SkillName,
                    LearningLevel = c.LearningLevel,
                    LearningStatus = c.LearningStatus
                }).ToListAsync();
            if (db == null)
            {
                response.Success = false;
                response.Message = "No CharacterSkill Data";
            }
            else
            {
                response.Data = db;
                response.Success = true;
                response.Message = "Have CharacterSkill";
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetCharacterSkillDto>>> GetCharacterSkill(SearchCharacterSkillForAdvisorDto searchCriteria)
        {
            var response = new ServiceResponse<List<GetCharacterSkillDto>>();
            try
            {
                var result = from c in _context.CharacterSkills select c;
                if (string.IsNullOrEmpty(searchCriteria.SearchText) && string.IsNullOrEmpty(searchCriteria.Status))
                {
                    response.Success = false;
                    response.Message = "CharacterSkill Search NotFound";
                    return response;
                }
                if (searchCriteria.Status != "Learning" && searchCriteria.Status != "Completed")
                {
                    response.Success = false;
                    response.Message = "CharacterSkill Search NotFound";
                    return response;
                }
                result = result.Where(c => (c.Character.User.Username.Contains(searchCriteria.SearchText) || c.Skill.SkillName.Contains(searchCriteria.SearchText)) && c.LearningStatus.Contains(searchCriteria.Status));
                response.Data = await result.Include(r => r.Character).ThenInclude(r => r.User).Include(r => r.Skill).Select(r => new GetCharacterSkillDto()
                {
                    Id = r.Id,
                    CharacterName = r.Character.User.Username,
                    SkillName = r.Skill.SkillName,
                    LearningLevel = r.LearningLevel,
                    LearningStatus = r.LearningStatus
                }).ToListAsync();
                response.Success = true;
                response.Message = "CharacterSkill Search Found";
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> AddCharacterSkill(List<AddCharacterSkillDto> newCharacterSkills)
        {
            var response = new ServiceResponse<GetCharacterDto>();
            try
            {
                foreach (var newCharacterSkill in newCharacterSkills)
                {
                    var character = await _context.Characters
                        .FirstOrDefaultAsync(c => c.CharacterId == newCharacterSkill.CharacterId);
                    if (character == null)
                    {
                        response.Success = false;
                        response.Message = "Character Not Found.";
                        return response;
                    }

                    var skill = await _context.Skills.FirstOrDefaultAsync(s => s.SkillId == newCharacterSkill.SkillId);
                    if (skill == null)
                    {
                        response.Success = false;
                        response.Message = "Skill Not Found.";
                        return response;
                    }
                    var characterSkill = new CharacterSkill()
                    {
                        CharacterId = newCharacterSkill.CharacterId,
                        SkillId = newCharacterSkill.SkillId,
                        LearningLevel = newCharacterSkill.LearningLevel,
                        LearningStatus = "Learning"
                    };
                    await _context.CharacterSkills.AddAsync(characterSkill);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<UpdateCharacterSkillDto>> UpdateCharacterSkill(int id)
        {
            var response = new ServiceResponse<UpdateCharacterSkillDto>();
            try
            {
                var characterskill = await _context.CharacterSkills.FirstOrDefaultAsync(cs => cs.Id == id);
                if (characterskill == null)
                {
                    response.Success = false;
                    response.Message = "CharacterSkill Not Found";
                    return response;
                }
                response.Message = "Skill Approved";
                characterskill.LearningStatus = "Completed";
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> AddCharacterQuest(AddCharacterQuestDto newCharacterQuest)
        {
            var response = new ServiceResponse<GetCharacterDto>();
            try
            {
                var character = await _context.Characters
                    .FirstOrDefaultAsync(c => c.CharacterId == newCharacterQuest.CharacterId && c.User.Id == GetUserId());
                if (character == null)
                {
                    response.Success = false;
                    response.Message = "Character Not Found.";
                    return response;
                }

                var quest = await _context.Quests.FirstOrDefaultAsync(q => q.QuestId == newCharacterQuest.QuestId);
                if (quest == null)
                {
                    response.Success = false;
                    response.Message = "Quest Not Found.";
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter)
        {
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
            try
            {
                var character = await _context.Characters
                .Include(c => c.User)
                .Include(c => c.Job)
                .Include(c => c.CharacterSkills).ThenInclude(cs => cs.Skill)
                .FirstOrDefaultAsync(c => c.CharacterId == updateCharacter.CharacterId);
                if (character.CharacterId == updateCharacter.CharacterId)
                {
                    var characterskill = await _context.CharacterSkills.FirstOrDefaultAsync(c => c.CharacterId == updateCharacter.CharacterId);
                    characterskill.LearningStatus = updateCharacter.LearningStatus;
                    if (character.Job.JobId == 1)
                    {
                        foreach (CharacterSkill skill in character.CharacterSkills)
                        {
                            if (characterskill == null)
                            {
                                response.Success = false;
                                response.Message = "No Skill in this Character";
                                return response;
                            }
                            else if (character.CharacterSkills.Count >= 3 && characterskill.LearningStatus == "Completed")
                            {
                                updateCharacter.JobId = character.Job.JobId + 1;
                            }
                        }
                    }
                    await _context.SaveChangesAsync();
                    response.Success = true;
                    response.Message = "Update Completed";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Character not found.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
