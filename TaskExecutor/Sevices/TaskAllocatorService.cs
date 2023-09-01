using TaskExecutor.Models;
using TaskExecutor.NewFolder;
using TaskExecutor.Repository;

namespace TaskAllocator.Sevices
{
    using Task = TaskExecutor.Models.Task;
    using TaskStatus = TaskExecutor.Models.TaskStatus;
    public class TaskAllocatorService
    {
        private static readonly TaskRepository _taskRepository = new TaskRepository();
        private static readonly NodeRepository _nodeRepository = new NodeRepository();

        public async void ExecuteNextTask(Task taskToExecute, Node node)
        {
            if (taskToExecute != null && node != null)
            {
                node.ChangeStatusTo(NodeStatus.Busy);
                taskToExecute.ChangeStatusTo(TaskStatus.Running);

                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.PostAsJsonAsync(node.Address + "/api/Task/executetask", new {TaskId = taskToExecute.Id});
                response.EnsureSuccessStatusCode();
            }
        }
    }
}
