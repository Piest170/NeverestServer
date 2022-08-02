using NeverestServer.Data.Dtos.Character;
using NeverestServer.Models;

namespace NeverestServer.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();
        Task<ServiceResponse<GetCharacterDto>> GetCharacter(int id);
        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter);
        Task<ServiceResponse<GetCharacterDto>> AddCharacterSkill(List<AddCharacterSkillDto> newCharacterSkill);
        Task<ServiceResponse<GetCharacterDto>> AddCharacterQuest(AddCharacterQuestDto newCharacterQuest);
    }
}
