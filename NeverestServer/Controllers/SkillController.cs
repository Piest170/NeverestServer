using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NeverestServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly DataContext _context;

        public SkillController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSkill()
        {
            var skill = await _context.Skills.ToListAsync();
            return Ok(skill);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSkill(int id)
        {
            var skill = await _context.Skills.FirstOrDefaultAsync(s => s.SkillId == id);
            if (skill != null)
            {
                return Ok(skill);
            }
            return NotFound("Skill Not in this List");
        }
    }
}
