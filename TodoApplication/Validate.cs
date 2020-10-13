namespace TodoApplication
{
    class Validate
    {
        internal bool IsValidTask(TaskTodo task)
        {
            return (!string.IsNullOrEmpty(task.Title) && !string.IsNullOrEmpty(task.Description) && task.FinishDate >= task.CreateDate);
        }
    }
}
