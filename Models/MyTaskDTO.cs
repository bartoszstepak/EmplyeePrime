using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_2.Models
{
    public class MyTaskDTO
    {

        public int id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public int createdBy { get; set; }
        public int assignedTo { get; set; }
        public TasksStatus status { get; set; }

    }

    public enum  TasksStatus
    {
        NEW = 2,
        ASSIGNED = 2,
        DONE = 3,
        ENDED = 4
    }
}
