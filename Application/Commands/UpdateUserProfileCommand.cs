using MediatR;

namespace TaskList_BusinessBooster.Application.Commands
{
    public class UpdateUserProfileCommand : IRequest
    {
        public int UserId { get; set; }
        public string NewName { get; set; }
        public string NewEmail { get; set; }
        public string NewPassword { get; set; }
    }
}
