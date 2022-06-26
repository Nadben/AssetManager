using AssetManager.Domain.Entities;

namespace AssetManager.Domain.Repositories
{
    public interface IUserRepository
    {
        Task AddUser(User user);
        Task<User> GetUser(string username);
        Task DeleteUser(string username);
        Task<bool> UserExists(string username);
    }
}
