namespace TaskExecutor.Models
{
    public class Task
    {
        public String TaskName { get; set; }
        public Guid Id { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime CreatedDatetime { get; set; }
        public DateTime ExecutionStartDatetime { get; set; }
        public DateTime ExecutionCompletedDatetime { get; set; }


        public Task(string taskName)
        {
            this.TaskName = taskName;
            Id = Guid.NewGuid();
            Status = TaskStatus.Pending;
            TaskName = taskName;
            CreatedDatetime = DateTime.Now;
        }

        public void ChangeStatusTo(TaskStatus taskStatus)
        {
            Status = taskStatus;
        }

        public void SetExecutionStartTime(DateTime dateTime)
        {
            ExecutionStartDatetime = dateTime;
        }

        public void SetExecutionCompletedTime(DateTime dateTime)
        {
            ExecutionCompletedDatetime = dateTime;
        }
    }
}
