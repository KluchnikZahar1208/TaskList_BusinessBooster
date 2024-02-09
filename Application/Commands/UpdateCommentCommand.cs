using MediatR;

namespace TaskList_BusinessBooster.Application.Commands
{
    public class UpdateCommentCommand : IRequest
    {
        public int CommentId { get; set; }
        public string NewComment { get; set; }
    }
}
