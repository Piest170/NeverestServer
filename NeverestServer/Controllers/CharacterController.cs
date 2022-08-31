using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
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

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var response = await _characterService.UpdateCharacter(updatedCharacter);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("Skill")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterSkillDto>>>> GetAllCharacterSkills()
        {
            return Ok(await _characterService.GetAllCharacterSkills());
        }

        [HttpPost("Skill")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> AddCharacterSkill(List<AddCharacterSkillDto> newCharacterSkill)
        {
            return Ok(await _characterService.AddCharacterSkill(newCharacterSkill));
        }

        [HttpPost("Skill/Search")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterSkillDto>>>> GetCharacterSkill(string searchstring, string status)
        {
            return Ok(await _characterService.GetCharacterSkill(searchstring, status));
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
