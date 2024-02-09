using MediatR;

namespace TaskList_BusinessBooster.Application.Commands
{
    public class UpdateTaskCommand : IRequest
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int TaskListId { get; set; }
    }
}
