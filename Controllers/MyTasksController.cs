using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using crud_2.Models;
using crud_2.Services;

namespace crud_2.Controllers
{

    [Route("api/MyTasks")]
    [ApiController]
    public class MyTasksController : ControllerBase
    {
        private readonly EmployeeContext _context;
        private readonly IMyTaskBLL _myTaskBLL;

        public MyTasksController(EmployeeContext context, IMyTaskBLL myTaskBLL)
        {
            _context = context;
            _myTaskBLL = myTaskBLL;
        }

        // GET: api/MyTasks
        [HttpGet]
        public IEnumerable<MyTaskDTO> GetTasks()
        {
            var tasks = this._myTaskBLL.getTasks();
            return tasks;
        }

        // GET: api/MyTasks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var myTask = await _context.MyTasks.FindAsync(id);

            if (myTask == null)
            {
                return NotFound();
            }

            return Ok(myTask);
        }

        // GET: api/MyTasks/5
        [HttpGet]
        [Route("User/{id}")]
        public async Task<IActionResult> GetTaskConnectedToUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var myTask = await _context.MyTasks.FindAsync(id);
            var userTasks = this._myTaskBLL.getUserTasks(id);

            if (userTasks == null)
            {
                return NotFound();
            }

            return Ok(userTasks);
        }

        // PUT: api/MyTasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask([FromRoute] int id, [FromBody] MyTask myTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != myTask.id)
            {
                return BadRequest();
            }

            _context.Entry(myTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyTaskExists(id))
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

        // POST: api/MyTasks
        [HttpPost]
        public async Task<IActionResult> PostTask([FromBody] MyTask myTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdTask = await _myTaskBLL.createTask(myTask);


            if (createdTask != null)
            {
                return Ok(createdTask);
            }
            
            return NotFound();
        }

        // DELETE: api/MyTasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var myTask = await _context.MyTasks.FindAsync(id);
            if (myTask == null)
            {
                return NotFound();
            }

            _context.MyTasks.Remove(myTask);
            await _context.SaveChangesAsync();

            return Ok(myTask);
        }

        private bool MyTaskExists(int id)
        {
            return _context.MyTasks.Any(e => e.id == id);
        }
    }
}