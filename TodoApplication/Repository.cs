using System;
using System.Collections.Generic;
using System.Linq;

namespace TodoApplication
{
    internal class Repository
    {
        public List<TaskTodo> Tasks { get; set; }
        public Repository()
        {
            Tasks = new List<TaskTodo>();
        }

        internal void Add(TaskTodo task)
        {
            Tasks.Add(task);
        }

        internal List<TaskTodo> GetTaskByStatus(Status status)
        {
            return Tasks.Where(_ => _.Status.Equals(status)).ToList();
        }
    }
}