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

    }
}