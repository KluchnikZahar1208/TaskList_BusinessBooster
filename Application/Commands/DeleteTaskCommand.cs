using MediatR;

namespace TaskList_BusinessBooster.Application.Commands
{
    public class DeleteTaskCommand : IRequest
    {
        public int TaskId { get; set; }
    }
}
