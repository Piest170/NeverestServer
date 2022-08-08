using NeverestServer.Data.Dtos.Character;
using NeverestServer.Models;
using NeverestServer.Services.CharacterService;
using System.Security.Claims;

namespace NeverestServer.Services.CharacterSevice
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
                .Where(c => c.User.Id == GetUserId())
                .ToListAsync();
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacter(int id)
        {
            var response = new ServiceResponse<GetCharacterDto>();
            var db = await _context.Characters
                .FirstOrDefaultAsync(c => c.CharacterId == id && c.User.Id == GetUserId());
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
                    .FirstOrDefaultAsync(c => c.CharacterId == updateCharacter.CharacterId);
                if (character.User.Id == GetUserId())
                {
                    if (character.Job.JobId == 1 && character.CharacterSkills.Count >= 3)
                    {
                        character.Job.JobId+=1;
                    }
                    await _context.SaveChangesAsync();
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
