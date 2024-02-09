using MediatR;
using TaskList_BusinessBooster.Application.Commands;
using TaskList_BusinessBooster.Domain.Entities;
using TaskList_BusinessBooster.Domain.Interfaces;

namespace TaskList_BusinessBooster.Application.Handlers
{
    public class AddCommentCommandHandler : IRequestHandler<AddCommentCommand, int>
    {
        private readonly ITaskCommentRepository _commentRepository;

        public AddCommentCommandHandler(ITaskCommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<int> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new TaskComment
            {
                Comment = request.Comment,
                TaskId = request.TaskId,
                UserId = request.UserId
            };

            return await _commentRepository.AddCommentAsync(comment);
        }
    }
}
