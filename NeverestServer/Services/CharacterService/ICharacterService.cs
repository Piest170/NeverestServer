using NeverestServer.Data.Dtos.Character;
using NeverestServer.Models;

namespace NeverestServer.Services
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();
        Task<ServiceResponse<GetCharacterDto>> GetCharacter(int id);
        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter);
        Task<ServiceResponse<List<GetCharacterSkillDto>>> GetAllCharacterSkills();
        Task<ServiceResponse<List<GetCharacterSkillDto>>> GetCharacterSkill(string searchstring, string status);
        Task<ServiceResponse<GetCharacterDto>> AddCharacterSkill(List<AddCharacterSkillDto> newCharacterSkill);
        Task<ServiceResponse<UpdateCharacterSkillDto>> UpdateCharacterSkill(int id);
        Task<ServiceResponse<GetCharacterDto>> AddCharacterQuest(AddCharacterQuestDto newCharacterQuest);
    }
}
