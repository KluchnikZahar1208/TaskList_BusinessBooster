using MediatR;

namespace TaskList_BusinessBooster.Application.Commands
{
    public class UpdateTaskListCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public UpdateTaskListCommand(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }
    }
}
