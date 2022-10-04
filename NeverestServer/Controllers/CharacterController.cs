using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using NeverestServer.Data.Dtos.Advisor;
using NeverestServer.Data.Dtos.Character;
using NeverestServer.Models;
using NeverestServer.Services;

namespace NeverestServer.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get()
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetCharacter(int id)
        {
            return Ok(await _characterService.GetCharacter(id));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var response = await _characterService.UpdateCharacter(updatedCharacter);
            return Ok(response);
        }

        [HttpGet("Skill/All")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterSkillForAdvisorDto>>>> GetAllCharacterSkills()
        {
            return Ok(await _characterService.GetAllCharacterSkills());
        }

        [HttpGet("Skill")]
        public async Task<ActionResult<ServiceResponse<GetCharacterSkillDto>>> GetCharacterSkill(int characterid, int skillid, int level)
        {
            return Ok(await _characterService.GetCharacterSkill(characterid, skillid, level));
        }

        [HttpPost("Skill")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> AddCharacterSkill(List<GetCharacterSkillDto> newCharacterSkill)
        {
            return Ok(await _characterService.AddCharacterSkill(newCharacterSkill));
        }

        [HttpPost("Skill/Search")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterSkillForAdvisorDto>>>> GetCharacterSkill(SearchCharacterSkillForAdvisorDto searchDto)
        {
            return Ok(await _characterService.GetCharacterSearchSkill(searchDto));
        }

        [HttpPut("Skill/{id}")]
        public async Task<ActionResult<ServiceResponse<UpdateCharacterSkillDto>>> UpdateCharacterSkill(int id)
        {
            return Ok(await _characterService.UpdateCharacterSkill(id));
        }

        [HttpPost("Quest")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> AddCharacterQuest(AddCharacterQuestDto newCharacterQuest)
        {
            return Ok(await _characterService.AddCharacterQuest(newCharacterQuest));
        }
    }
}
