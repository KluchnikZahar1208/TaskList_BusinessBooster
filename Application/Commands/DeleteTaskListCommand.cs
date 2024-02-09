using MediatR;

namespace TaskList_BusinessBooster.Application.Commands
{
    public class DeleteTaskListCommand : IRequest<Unit>
    {
        public int Id { get; }

        public DeleteTaskListCommand(int id)
        {
            Id = id;
        }
    }
}
