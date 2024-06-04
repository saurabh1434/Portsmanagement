using MaritimeAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortsManagement.Models;

namespace PortsManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortsController : ControllerBase
    {
        private readonly MaritimeContext _context;

        public PortsController(MaritimeContext context)
        {
            _context = context;
        }

        // GET: api/Ports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Port>>> GetPorts()
        {
            return await _context.Ports.Include(p => p.Terminals).ToListAsync();
        }

        // GET: api/Ports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Port>> GetPort(string id)
        {
            var port = await _context.Ports.Include(p => p.Terminals).FirstOrDefaultAsync(p => p.PortCode == id);

            if (port == null)
            {
                return NotFound();
            }

            return port;
        }

        // PUT: api/Ports/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPort(string id, Port port)
        {
            if (id != port.PortCode)
            {
                return BadRequest();
            }

            port.LastEditedDate = DateTime.UtcNow;
            _context.Entry(port).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PortExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Ports
        [HttpPost]
        public async Task<ActionResult<Port>> PostPort(Port port)
        {
            _context.Ports.Add(port);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPort", new { id = port.PortCode }, port);
        }

        // DELETE: api/Ports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePort(string id)
        {
            var port = await _context.Ports.FindAsync(id);
            if (port == null)
            {
                return NotFound();
            }

            _context.Ports.Remove(port);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PortExists(string id)
        {
            return _context.Ports.Any(e => e.PortCode == id);
        }
    }
}
