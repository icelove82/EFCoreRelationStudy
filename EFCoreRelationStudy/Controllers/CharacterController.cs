using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly DataContext _context;

        public CharacterController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<List<Character>>> Get(int userId)
        {
            var characters = await _context.Characters
                .Where(c => c.UserId == userId)
                .Include(c => c.User)
                .ToListAsync();

            return Ok(characters);
        }

        [HttpPost]
        public async Task<ActionResult<List<Character>>> Create(Character character)
        {
            var user = await _context.Users.FindAsync(character.UserId);
            if (user == null)
                return NotFound("User not found.");

            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            return Ok(await GetDbCharacters(user.Id));
        }

        private async Task<List<Character>> GetDbCharacters(int userId)
        {
            return await _context.Characters
                .Where(c => c.UserId == userId)
                .ToListAsync();
        }
    }
}
