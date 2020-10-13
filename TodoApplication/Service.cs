using System;
using System.Collections.Generic;

namespace TodoApplication
{
    internal class Service
    {
        private readonly Repository _repository;
        public Service()
        {
            _repository = new Repository();
        }

        internal void Add(TaskTodo task)
        {
            _repository.Add(task);
        }

        internal List<TaskTodo> GetTaskByStatus(Status status)
        {
            return _repository.GetTaskByStatus(status);
        }

        internal void SetStatusByLsName(TaskTodo task, string name)
        {
            if (name.Equals("listBackLog"))
                _repository.SetStatus(task, Status.BackLog);

            if (name.Equals("lsResolved"))
                _repository.SetStatus(task, Status.Resolved);

            if (name.Equals("lsClosed"))
                _repository.SetStatus(task, Status.Closed);
        }
    }
}