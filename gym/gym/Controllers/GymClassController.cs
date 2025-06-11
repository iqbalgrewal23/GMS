using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gym.Models;


namespace Gym.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GymClassController : ControllerBase
    {
        private readonly GymContext _context;

        public GymClassController(GymContext context)
        {
            _context = context;
        }

        // GET: api/gymclass
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GymClass>>> GetGymClasses()
        {
            return await _context.GymClasses
                .Include(gc => gc.Trainer)
                .ToListAsync();
        }

        // GET: api/gymclass/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GymClass>> GetGymClass(int id)
        {
            var gymClass = await _context.GymClasses
                .Include(gc => gc.Trainer)
                .FirstOrDefaultAsync(gc => gc.Id == id);

            if (gymClass == null)
            {
                return NotFound();
            }

            return gymClass;
        }

        // POST: api/gymclass
        [HttpPost]
        public async Task<ActionResult<GymClass>> PostGymClass(GymClass gymClass)
        {
            _context.GymClasses.Add(gymClass);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGymClass), new { id = gymClass.Id }, gymClass);
        }

        // PUT: api/gymclass/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGymClass(int id, GymClass gymClass)
        {
            if (id != gymClass.Id)
            {
                return BadRequest();
            }

            _context.Entry(gymClass).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/gymclass/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGymClass(int id)
        {
            var gymClass = await _context.GymClasses.FindAsync(id);
            if (gymClass == null)
            {
                return NotFound();
            }

            _context.GymClasses.Remove(gymClass);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
