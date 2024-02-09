using MediatR;

namespace TaskList_BusinessBooster.Application.Commands
{
    public class AddTaskStatusHistoryCommand : IRequest<int>
    {
        public int TaskId { get; set; }
        public string NewStatus { get; set; }
        public string OldStatus { get; set; }
        public string DateChanged { get; set; }

        public AddTaskStatusHistoryCommand(int taskId, string oldStatus, string newStatus, string dateChanged)
        {
            TaskId = taskId;
            OldStatus = oldStatus;
            NewStatus = newStatus;
            DateChanged = dateChanged;
        }
    }
}
