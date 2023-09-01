namespace TaskExecutor.Repository
{
    using Task = TaskExecutor.Models.Task;
    public class TaskRepository
    {
        private static readonly List<Task> _task = new List<Task>();

        public Task AddTask(Task task)
        {
            _task.Add(task);
            return task;
        }

        public Task GetNextTaskToRun()
        {
            return _task.FirstOrDefault(_ => _.Status == Models.TaskStatus.Pending);
        }

        public void UpdateTask(Task task)
        {
            var taskToUpdate = _task.FirstOrDefault(_ => _.Id.Equals(task.Id));
            if (taskToUpdate != null)
            {
                taskToUpdate.ChangeStatusTo(task.Status);
                taskToUpdate.SetExecutionCompletedTime(task.ExecutionCompletedDatetime);
                taskToUpdate.SetExecutionStartTime(task.ExecutionStartDatetime);
            }
            else
            {
                throw new Exception("Task with Id: " + task.Id + " does not exists.");
            }
        }
    }
}
