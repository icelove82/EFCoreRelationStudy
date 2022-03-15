using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationStudy.Controllers
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

        [HttpPost("addto/character")]
        public async Task<ActionResult<Character>> AddSkillToCharacter(CharacterAddSkill req)
        {
            var character = await _context.Characters
                .Where(c => c.Id == req.CharacterId)
                .Include(c => c.Skills)
                .FirstOrDefaultAsync();
            if (character == null)
                return NotFound("Character not found.");

            var skill = await _context.Skills.FindAsync(req.SkillId);
            if (skill == null)
                return NotFound("Skill not found.");

            character?.Skills?.Add(skill);
            await _context.SaveChangesAsync();

            return Ok(character);
        }
    }
}
