using MediatR;

namespace TaskList_BusinessBooster.Application.Commands
{
    public class AddTaskListCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }

        public AddTaskListCommand(string title, string description, int userId)
        {
            Title = title;
            Description = description;
            UserId = userId;
        }
    }
}
