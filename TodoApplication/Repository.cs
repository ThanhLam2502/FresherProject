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
            Tasks = new List<TaskTodo>() {
                new TaskTodo{
                    Title = "a",
                    Description = "aa",
                },
                new TaskTodo{
                    Title = "b",
                    Description = "bb",
                    Status = Status.Closed,
                },
                new TaskTodo{
                    Title = "c",
                    Description = "cc",
                },
                new TaskTodo{
                    Title = "d",
                    Description = "dd",
                },
            };
        }

        internal void Add(TaskTodo task)
        {
            Tasks.Add(task);
        }

        internal List<TaskTodo> GetTaskByStatus(Status status)
        {
            return Tasks.Where(_ => _.Status.Equals(status)).ToList();
        }

        internal void SetStatus(TaskTodo task, Status status)
        {
            task.Status = status;
        }
    }
}