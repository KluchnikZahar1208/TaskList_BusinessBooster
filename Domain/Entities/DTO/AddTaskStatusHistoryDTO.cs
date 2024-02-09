namespace TaskList_BusinessBooster.Domain.Entities.DTO
{
    public class AddTaskStatusHistoryDTO
    {
        public int TaskId { get; set; }
        public string OldStatus { get; set; }
        public string NewStatus { get; set; }

    }
}
