using MediatR;
using TaskList_BusinessBooster.Domain.Entities;

namespace TaskList_BusinessBooster.Application.Commands
{
    public class GetCommentByIdCommand : IRequest<TaskComment>
    {
        public int CommentId { get; set; }
    }
}
