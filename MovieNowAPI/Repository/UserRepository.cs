using Microsoft.EntityFrameworkCore;
using MovieNowAPI.Entities;

namespace MovieNowAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private MovienowDbContext context;

        public UserRepository(MovienowDbContext context)
        {
            this.context = context;
        }

        public async Task<User> GetUserById(int id)
        {
            return await context.Users.FindAsync(id);
        }

        public async Task<User> GetUserByUsername(string username)
        {
            var user = await context.Users.Select(
                x => new User
                {
                    Id = x.Id,
                    Username = x.Username,
                    Password = x.Password
                })
                .FirstOrDefaultAsync(x => x.Username == username);
            return user;
        }

        public async Task AddUser(User user)
        {
            await context.Users.AddAsync(user);
        }

        public async Task DeleteUser(int id)
        {
            User user = await context.Users.FindAsync(id);
            context.Users.Remove(user);
        }

        public async Task UpdateUser(User user)
        {
            context.Entry(user).State = EntityState.Modified;
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
