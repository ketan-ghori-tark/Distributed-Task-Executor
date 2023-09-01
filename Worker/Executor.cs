using Worker.Model;

namespace Worker
{
    public class Executor
    {
        private readonly WorkerInfo _workerInfo;
        private readonly int TIMEOUT_SECONDS = 30;

        public Executor(WorkerInfo workerInfo)
        {
            _workerInfo = workerInfo;
        }

        public async void ExecuteTask(String taskId)
        {
            DateTime executionStartTime = DateTime.Now;
            DateTime executionEndTime;

            HttpClient client = new HttpClient();

            var taskExecutionStatus = Task.Run(async () => await DownloadMeme(taskId));

            if (!downloadMemeTask.Wait(TimeSpan.FromSeconds(TIMEOUT_SECONDS)))
            {
                task.ChangeStatusToFailed();
            }

            TaskResponse executedTask = new TaskResponse(task, _workerInfo.Name);
            HttpResponseMessage updateTaskResponse = await client.PutAsJsonAsync("http://localhost:5000/api/Tasks/executed", executedTask);
            updateTaskResponse.EnsureSuccessStatusCode();
        }

        private async Task<TaskExecutionStatus> DownloadMeme(String taskId)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage memeResponse = await client.GetAsync("https://meme-api.com/gimme/wholesomememes");
            memeResponse.EnsureSuccessStatusCode();

            var meme = await memeResponse.Content.ReadFromJsonAsync<Meme>();
            if (meme == null || meme.NSFW)
            {
                return TaskExecutionStatus.Failed;
            }
            else
            {
                await DownloadImage(meme.URL);
                return TaskExecutionStatus.Executed;
            }

            return TaskExecutionStatus.Unknown;
        }

        public async System.Threading.Tasks.Task DownloadImage(string imageUrl)
        {
            var fileName = GetFileName(imageUrl);
            HttpClient httpClient = new HttpClient();
            byte[] fileBytes = await httpClient.GetByteArrayAsync(imageUrl);
            await File.WriteAllBytesAsync(_workerInfo.WorkDir + fileName, fileBytes);
        }

        private string GetFileName(string url)
        {
            return url.Split('/').LastOrDefault();
        }
    }
}
}
