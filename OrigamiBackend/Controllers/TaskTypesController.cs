﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrigamiBackend.Data;

namespace OrigamiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public TaskTypesController(DataContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskCategory>>> GetTaskTypes()
        {
            var tasks= await _context.TaskCategory.ToListAsync();
            return Ok(tasks);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskCategory>> GetTaskType(int id)
        {
            var taskType = await _context.TaskCategory.FindAsync(id);

            if (taskType == null)
            {
                return NotFound();
            }

            return Ok(taskType);
        }
        
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskType(int id, TaskCategory taskType)
        {
            if (id != taskType.Id)
            {
                return BadRequest();
            }

            _context.Entry(taskType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskTypeExists(id))
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
        public async Task<ActionResult<TaskCategory>> PostTaskType(TaskCategory taskType)
        {
            _context.TaskCategory.Add(taskType);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskType(int id)
        {
            var taskType = await _context.TaskCategory.FindAsync(id);
            if (taskType == null)
            {
                return NotFound();
            }

            _context.TaskCategory.Remove(taskType);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool TaskTypeExists(int id)
        {
            return _context.TaskCategory.Any(e => e.Id == id);
        }
    }
}