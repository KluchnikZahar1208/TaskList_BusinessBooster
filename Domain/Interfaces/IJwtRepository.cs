using TaskList_BusinessBooster.Domain.Entities;

namespace TaskList_BusinessBooster.Domain.Interfaces
{
    public interface IJwtRepository
    {
        string GenerateToken(User user);
    }
}
