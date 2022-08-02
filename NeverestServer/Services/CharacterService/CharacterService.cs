using AutoMapper;
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
        //private readonly IMapper _mapper;

        public CharacterService(/*IMapper mapper,*/ DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            //_mapper = mapper;
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
                .Include(c => c.Advisor)
                //.Include(c => c.Skills)
                .Include(c => c.Job)
                .Where(c => c.User.UserId == GetUserId())
                .ToListAsync();
            //response.Data = db.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacter(int id)
        {
            var response = new ServiceResponse<GetCharacterDto>();
            var db = await _context.Characters
                .Include(c => c.User)
                .Include(c => c.Advisor)
                //.Include(c => c.Skills)
                .Include(c => c.Job)
                .FirstOrDefaultAsync(c => c.CharacterId == id && c.User.UserId == GetUserId());
            return response;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
                //Character character = _mapper.Map<Character>(newCharacter);
                //character.User = await _context.Users.FirstOrDefaultAsync(u => u.UserId == GetUserId());
                //if (character == null)
                //{
                //    _context.Characters.Add(character);
                //    await _context.SaveChangesAsync();
                //    serviceResponse.Data = await _context.Characters
                //        .Where(c => c.User.UserId == GetUserId())
                //        .Select(c => _mapper.Map<GetCharacterDto>(c))
                //        .ToListAsync();
                //}
                //else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Character has Already Created.";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> AddCharacterSkill(List<AddCharacterSkillDto> newCharacterSkills)
        {
            var response = new ServiceResponse<GetCharacterDto>();
            try
            {
                foreach (var newCharacterSkill in newCharacterSkills)
                {
                    var character = await _context.Characters
                        //.Include(c => c.Skills)
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
            catch
            {

            }
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> AddCharacterQuest(AddCharacterQuestDto newCharacterQuest)
        {
            var response = new ServiceResponse<GetCharacterDto>();
            try
            {
                var character = await _context.Characters
                    //.Include(c => c.Quests)
                    .FirstOrDefaultAsync(c => c.CharacterId == newCharacterQuest.CharacterId && c.User.UserId == GetUserId());
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
                }
            }
            catch
            {

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
                    .FirstOrDefaultAsync(c => c.CharacterId == updateCharacter.CharacterId);
                if (character.User.UserId == GetUserId())
                {
                    var job = await _context.Jobs
                        .Include(j => j.Skills)
                        .FirstOrDefaultAsync(j => j.JobId == updateCharacter.JobId);
                    if (job.JobId == 1)
                    {

                    }
                    character.CharacterName = updateCharacter.CharacterName;

                    await _context.SaveChangesAsync();

                    //response.Data = _mapper.Map<GetCharacterDto>(character);
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
