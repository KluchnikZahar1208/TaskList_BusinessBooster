using MediatR;

namespace TaskList_BusinessBooster.Application.Commands
{
    public class DeleteCommentCommand : IRequest
    {
        public int CommentId { get; set; }
    }
}
