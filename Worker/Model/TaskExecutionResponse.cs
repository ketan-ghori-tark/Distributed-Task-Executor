namespace Worker.Model
{
    public class TaskExecutionResponse
    {
        public String TaskId { get; set; }
        public DateTime executionStartTime { get; set; }
        public DateTime executionEndTime { get; set; }
        public  TaskExecutionStatus TaskExecutionStatus { get; set; }
        public String ProcessedNodeName{ get; set; }
    }
}
