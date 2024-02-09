using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskList_BusinessBooster.Domain.Entities;
using TaskList_BusinessBooster.Domain.Entities.DTO;
using TaskList_BusinessBooster.Domain.Interfaces;
using TaskList_BusinessBooster.Infrastructure;

namespace TaskList_BusinessBooster.Infrastructure.Data.Services
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _db;
        public AuthRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<User> LoginAsync(UserDTO userDTO)
        {
            User userFound = _db.Users.FirstOrDefault(x => x.Email == userDTO.Email);
            if (userDTO == null || userFound.Password != userDTO.Password)
            {
                return null;
            }
            return userFound;
        }

        public async Task<bool> RegistrationAsync(UserDTO userDTO)
        {
            if (await _db.Users.AnyAsync(u => u.Name == userDTO.UserName))
            {
                return false;
            }
            User user = new User { Email = userDTO.Email, Name = userDTO.UserName, Password = userDTO.Password };
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
