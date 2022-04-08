using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrigamiBackend.Data;

namespace OrigamiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class TaskStatusController : ControllerBase
    {
        private readonly DataContext _context;

        public TaskStatusController(DataContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskStatus>>> GetStatuses()
        {
            var statuses= await _context.TaskStatus.ToListAsync();
            return Ok(statuses);
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskStatus>> GetStatus(int id)
        {
            var status = await _context.TaskStatus.FindAsync(id);

            if (status == null)
            {
                return NotFound();
            }

            return Ok(status);
        }

   
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatus(int id, TaskStatus status)
        {
            if (id != status.Id)
            {
                return BadRequest();
            }

            _context.Entry(status).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        
        [HttpPost]
        public async Task<ActionResult<TaskStatus>> PostStatus(TaskStatus status)
        {
            _context.TaskStatus.Add(status);
            await _context.SaveChangesAsync();

            return Ok();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatus(int id)
        {
            var status = await _context.TaskStatus.FindAsync(id);
            if (status == null)
            {
                return NotFound();
            }

            _context.TaskStatus.Remove(status);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool StatusExists(int id)
        {
            return _context.TaskStatus.Any(e => e.Id == id);
        }
    }
    
}