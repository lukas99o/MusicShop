using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MusicShop.Data;
using MusicShop.Models;
using MusicShop.Repository.IRepository;

namespace MusicShop.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MusicDbContext _context;

        public UserRepository(MusicDbContext context)
        {
            _context = context;
        }

        public async Task RegisterUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task LoginUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task ResetPasswordAsync(int id, string password)
        {
            var user = await _context.Users.FindAsync(id);
            user.Password = password;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
