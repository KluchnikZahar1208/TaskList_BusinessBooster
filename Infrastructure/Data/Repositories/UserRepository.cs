using Microsoft.EntityFrameworkCore;
using TaskList_BusinessBooster.Domain.Entities;
using TaskList_BusinessBooster.Domain.Entities.DTO;
using TaskList_BusinessBooster.Domain.Interfaces;
using TaskList_BusinessBooster.Infrastructure;
using Task = System.Threading.Tasks.Task;

namespace TaskList_BusinessBooster.Infrastructure.Data.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _data;

        public UserRepository(AppDbContext data)
        {
            _data = data;
        }

        public async Task<int> AddUserAsync(User user)
        {
            _data.Users.Add(user);
            await _data.SaveChangesAsync();
            return user.Id;
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _data.Users.FindAsync(id);
            if (user != null)
            {
                _data.Users.Remove(user);
                await _data.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _data.Users.ToListAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _data.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _data.Users.FindAsync(id);
        }

        public async Task UpdateUserAsync(User user)
        {
            _data.Entry(user).State = EntityState.Modified;
            await _data.SaveChangesAsync();
        }

        public async Task<User> UpdateUserProfile(int userId, UserDTO user)
        {
            var existingUser = await _data.Users.FindAsync(userId);
            if (existingUser == null)
            {
                throw new Exception("User not found");
            }
            existingUser.Email = user.Email;
            existingUser.Name = user.UserName;
            existingUser.Password = user.Password;
            _data.SaveChanges();

            return existingUser;
        }
    }
}
