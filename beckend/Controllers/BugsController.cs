namespace beckend.Controllers
{
    using beckend.Data;
    using beckend.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [ApiController]
    [Route("/[controller]")]
    public class BugsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BugsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BugItem>>> GetBugs()
        {
            return await _context.Bugs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BugItem>> GetBug(int id)
        {
            var task = await _context.Bugs.FindAsync(id);
            if (task == null) return NotFound();
            return task;
        }

        [HttpPost]
        public async Task<ActionResult<BugItem>> CreateBug(BugItem bug)
        {
            _context.Bugs.Add(bug);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBug), new { id = bug.Id }, bug);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBug(int id, BugItem bug)
        {
            if (id != bug.Id) return BadRequest();

            _context.Entry(bug).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBug(int id)
        {
            var task = await _context.Bugs.FindAsync(id);
            if (task == null) return NotFound();

            _context.Bugs.Remove(task);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}