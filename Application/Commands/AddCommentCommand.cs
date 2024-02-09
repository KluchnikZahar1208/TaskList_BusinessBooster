using MediatR;

namespace TaskList_BusinessBooster.Application.Commands
{
    public class AddCommentCommand : IRequest<int>
    {
        public string Comment { get; set; }
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public AddCommentCommand(string comment, int taskId, int userId)
        {
            Comment = comment;
            TaskId = taskId;
            UserId = userId;
        }
    }
}
