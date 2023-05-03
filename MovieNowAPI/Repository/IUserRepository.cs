using MovieNowAPI.Entities;

namespace MovieNowAPI.Repository
{
    public interface IUserRepository : IDisposable
    {
        Task<User> GetUserById(int id);
        Task<User> GetUserByUsername(string username);
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(int id);
        Task Save();

    }
}
