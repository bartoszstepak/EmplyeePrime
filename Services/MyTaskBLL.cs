using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using crud_2.Models;
using Microsoft.EntityFrameworkCore;

namespace crud_2.Services
{
    public class MyTaskBLL : IMyTaskBLL
    {
        private EmployeeContext _context;
        private IMapper _mapper;

        public MyTaskBLL(EmployeeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<MyTaskDTO> GetTasks()
        {
            IEnumerable<MyTask> tasks = _context.MyTasks.ToList();
            var myTasks = _mapper.Map<MyTaskDTO[]>(tasks).ToList();
            var sortedTasks = TaskHelper.sortTasksByStatus(myTasks);
            return sortedTasks;
        }

        public IEnumerable<MyTaskDTO> GetUserTasks(int id)
        {
            var tasks = this.GetTasks();
            var myTasks = tasks.Where(task => task.assignedTo == id && task.status != TasksStatus.ENDED).ToList();
            var sortedTasks = TaskHelper.sortTasksByStatus(myTasks);
            return sortedTasks;
        }

        public async Task<MyTask> CreateTask(MyTask task)
        {
                _context.MyTasks.Add(task);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return null;
                }
                return task;

        }

        public async Task<MyTaskDTO> GetTask(int id)
        {
            var query = await _context.MyTasks.FindAsync(id);
            var task = _mapper.Map<MyTaskDTO>(query);

            return task;

        }

        public async Task<bool> UpdateTask(int id, MyTask myTask)
        {
            _context.Entry(myTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!CheckIfMyTaskExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        private bool CheckIfMyTaskExists(int id)
        {
                return _context.MyTasks.Any(e => e.id == id);
        }

        public async Task<bool> DeleteTask(int id)
        {
            var myTask = await _context.MyTasks.FindAsync(id);

            if (myTask != null)
            {
                _context.MyTasks.Remove(myTask);
                try
                {
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (DbUpdateConcurrencyException)
                {
                    return false;
                }
            }

            return false;
        }

    }



    public static class TaskHelper {

        public static List<MyTaskDTO> sortTasksByStatus(List<MyTaskDTO> tasks)
        {
            return tasks.OrderBy(task => task.status).ToList(); 
        }

    }



}
