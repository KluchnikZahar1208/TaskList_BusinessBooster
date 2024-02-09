using MediatR;
using TaskList_BusinessBooster.Application.Commands;
using TaskList_BusinessBooster.Domain.Entities;
using TaskList_BusinessBooster.Domain.Interfaces;

namespace TaskList_BusinessBooster.Application.Handlers
{
    public class GetCommentByTaskIdCommandHandler : IRequestHandler<GetCommentByTaskIdCommand, IEnumerable<TaskComment>>
    {
        private readonly ITaskCommentRepository _taskCommentRepository;

        public GetCommentByTaskIdCommandHandler(ITaskCommentRepository taskCommentRepository)
        {
            _taskCommentRepository = taskCommentRepository;
        }

        public async Task<IEnumerable<TaskComment>> Handle(GetCommentByTaskIdCommand request, CancellationToken cancellationToken)
        {
            return await _taskCommentRepository.GetCommentByTaskIdAsync(request.TaskId);
        }
    }
}
