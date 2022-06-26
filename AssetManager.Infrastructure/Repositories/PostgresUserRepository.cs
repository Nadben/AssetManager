using AssetManager.Domain.Entities;
using AssetManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AssetManager.Infrastructure.Repositories
{
    internal class PostgresUserRepository : IUserRepository
    {
        private readonly AssetManagerContext _context;

        public PostgresUserRepository(AssetManagerContext context)
        {
            _context = context;
        }

        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task DeleteUser(string username)
        {
            // delete the user
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            _context.Users.Remove(user);

        }

        public async Task<User> GetUser(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(u => u.Username == username);
        }
    }
}
