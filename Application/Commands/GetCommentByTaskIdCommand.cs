using MediatR;
using TaskList_BusinessBooster.Domain.Entities;

namespace TaskList_BusinessBooster.Application.Commands
{
    public class GetCommentByTaskIdCommand : IRequest<IEnumerable<TaskComment>>
    {
        public int TaskId { get; set; }

        public GetCommentByTaskIdCommand(int taskId)
        {
            TaskId = taskId;
        }
    }
}
