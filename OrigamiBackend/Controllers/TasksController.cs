using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OrigamiBackend;
using OrigamiBackend.Data;
using OrigamiBackend.Helper;


namespace OrigamiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly DataContext _context;

        public TasksController(DataContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Task>>> GetTasks()
        {
            var tasks= await _context.Task.ToListAsync();
            return Ok(tasks);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Task>> GetTask(int id)
        {
            var task = await _context.Task.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(int id, Task task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            _context.Entry(task).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
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
        public async Task<ActionResult<Task>> PostTask(Task task)
        {
            _context.Task.Add(task);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.Task.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            _context.Task.Remove(task);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool TaskExists(int id)
        {
            return _context.Task.Any(e => e.Id == id);
        }

        #region Devx Process

        [HttpGet("devx")]
        public async Task<IActionResult> GetDevx(DataSourceLoadOptions loadOptions)
        {
            loadOptions.PrimaryKey = new[] {"id"};
            loadOptions.PaginateViaPrimaryKey = true;
            var source = _context.Task
                ;
            return Ok(await DataSourceLoader.LoadAsync(source, loadOptions));
        }

        [HttpPost("devx")]
        public async Task<IActionResult> PostDevx(string values)
        {
            var obje = new Task();
            JsonConvert.PopulateObject(values, obje);
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            await _context.Task.AddAsync(obje);
            try
            {
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

        [HttpPut("devx")]
        public async Task<IActionResult> PutDevx(int key, string values)
        {
            var obje = await _context.Task
                .Where(p => p.Id == key).FirstOrDefaultAsync();
            if (obje == null)
            {
                return StatusCode(409, "Kayıt bulunamadı");
            }

            JsonConvert.PopulateObject(values, obje);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            _context.Entry(obje).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }

        #endregion
    }
}