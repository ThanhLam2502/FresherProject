using System;

namespace TodoApplication
{
    internal class TaskTodo
    {
        public string Title { get; internal set; }
        public string Description { get; internal set; }
        public DateTime CreateDate { get; internal set; }
        public DateTime FinishDate { get; internal set; }
        public Status Status { get; internal set; }
    }
}