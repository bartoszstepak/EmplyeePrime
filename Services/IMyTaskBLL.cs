using crud_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_2.Services
{
    public interface IMyTaskBLL
    {
        IEnumerable<MyTaskDTO> GetUserTasks(int id);
        IEnumerable<MyTaskDTO> GetTasks();
        Task<MyTask> CreateTask(MyTask task);
        Task<MyTaskDTO> GetTask(int id);
        Task<bool> UpdateTask(int id, MyTask myTask);
        Task<bool> DeleteTask(int id);
    }
}
