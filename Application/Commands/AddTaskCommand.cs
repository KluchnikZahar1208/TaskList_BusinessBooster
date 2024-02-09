using MediatR;

namespace TaskList_BusinessBooster.Application.Commands
{
    public class AddTaskCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TaskListId { get; set; }
        public string Status { get; set; }
    }
}
