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
        private readonly IMyTaskBLL _myTaskBLL;

        public MyTasksController( IMyTaskBLL myTaskBLL)
        {
            _myTaskBLL = myTaskBLL;
        }

        [HttpGet]
        public IEnumerable<MyTaskDTO> GetTasks()
        {
            var tasks = this._myTaskBLL.GetTasks();
            return tasks;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var myTask = await _myTaskBLL.GetTask(id);

            if (myTask == null)
            {
                return NotFound();
            }

            return Ok(myTask);
        }

        [HttpGet]
        [Route("User/{id}")]
        public async Task<IActionResult> GetTaskConnectedToUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userTasks =  _myTaskBLL.GetUserTasks(id);

            if (userTasks == null)
            {
                return NotFound();
            }

            return Ok(userTasks);
        }

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

            var isTaskSeved = await _myTaskBLL.UpdateTask(id, myTask);

            if (isTaskSeved) {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> PostTask([FromBody] MyTask myTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdTask = await _myTaskBLL.CreateTask(myTask);


            if (createdTask != null)
            {
                return Ok(createdTask);
            }
            
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deletedTask = await _myTaskBLL.GetTask(id);

            if(deletedTask == null)
            {
                return NotFound();
            }

            var isTaskDeleted = await _myTaskBLL.DeleteTask(id);

            if (isTaskDeleted) 
            {
                return Ok(deletedTask);
            }

            return NotFound();
        }

    }
}