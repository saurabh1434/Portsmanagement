using Microsoft.AspNetCore.Mvc;
using MaritimeAPI.Data;
using System.Linq;
using System.Threading.Tasks;
using PortsManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace MaritimeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerminalsController : ControllerBase
    {
        private readonly MaritimeContext _context;

        public TerminalsController(MaritimeContext context)
        {
            _context = context;
        }

        // GET: api/Terminals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Terminal>>> GetTerminals()
        {
            return await _context.Terminals.Include(t => t.Port).ToListAsync();
        }

        // GET: api/Terminals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Terminal>> GetTerminal(int id)
        {
            var terminal = await _context.Terminals.Include(t => t.Port).FirstOrDefaultAsync(t => t.Id == id);

            if (terminal == null)
            {
                return NotFound();
            }

            return terminal;
        }

        // PUT: api/Terminals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTerminal(int id, Terminal terminal)
        {
            if (id != terminal.Id)
            {
                return BadRequest();
            }

            terminal.LastEditedDate = DateTime.UtcNow;
            _context.Entry(terminal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                { 
                    throw;
                }
            }

            return NoContent();
        }

        ///POST: api/Terminals
        [HttpPost]
        public async Task<ActionResult<Terminal>> PostTerminal(Terminal terminal)
        {
            _context.Terminals.Add(terminal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTerminal", new { id = terminal.Id }, terminal);
        }
    }
}