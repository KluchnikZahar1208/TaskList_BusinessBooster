using MediatR;
using TaskList_BusinessBooster.Application.Commands;
using TaskList_BusinessBooster.Domain.Interfaces;

namespace TaskList_BusinessBooster.Application.Handlers
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand>
    {
        private readonly ITaskCommentRepository _commentRepository;

        public DeleteCommentCommandHandler(ITaskCommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var existingComment = await _commentRepository.GetCommentByIdAsync(request.CommentId);

            if (existingComment == null)
            {
                throw new ArgumentException($"Comment with ID {request.CommentId} not found.");
            }

            await _commentRepository.DeleteCommentAsync(existingComment.Id);

            return Unit.Value;
        }
    }
}
