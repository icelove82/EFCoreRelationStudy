using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponController : ControllerBase
    {
        private readonly DataContext _context;

        public WeaponController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<Character>>> Create(Weapon weapon)
        {
            var character = await _context.Characters.FindAsync(weapon.CharacterId);
            if (character == null)
                return BadRequest("Character not found.");

            _context.Weapons.Add(weapon);
            await _context.SaveChangesAsync();

            return Ok(await GetDbCharacters(character.Id));
        }

        private async Task<List<Character>> GetDbCharacters(int characterId)
        {
            return await _context.Characters
                .Where(c => c.Id == characterId)
                .Include(c => c.User)
                .Include(c => c.Weapon)
                .ToListAsync();
        }
    }
}
