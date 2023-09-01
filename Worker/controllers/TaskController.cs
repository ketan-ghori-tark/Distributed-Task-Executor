using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Worker.Model;

namespace Worker.Controllers
{
        public class TaskController : ControllerBase
        {
            private readonly WorkerInfo _workerInfo;
            public TaskController(WorkerInfo workerInfo)
            {
                _workerInfo = workerInfo;
            }

            [HttpPost("executetask")]
            public IActionResult Executetask([FromBody] TaskExecutionRequest taskExecutionRequest)
            {
                new Executor(_workerInfo).ExecuteTask(taskExecutionRequest.TaskId);
                return Ok();
            }
        }
    
}
