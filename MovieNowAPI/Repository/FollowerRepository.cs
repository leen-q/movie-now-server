using Microsoft.EntityFrameworkCore;
using MovieNowAPI.Entities;

namespace MovieNowAPI.Repository
{
    public class FollowerRepository : IFollowerRepository
    {
        private MovienowDbContext context;

        public FollowerRepository(MovienowDbContext context)
        {
            this.context = context;
        }

        public async Task AddFollower(Follower follower)
        {
            await context.Followers.AddAsync(follower);
        }

        public async Task DeleteFollower(int id)
        {
            Follower follower = await context.Followers.FindAsync(id);
            context.Followers.Remove(follower);
        }

        public async Task<Follower> GetFollowerById(int id)
        {
            return await context.Followers.FindAsync(id);
        }

        public async Task<List<Follower>> GetFollowers(int userId)
        {
            var followers = await context.Followers.Where(x => x.UserId == userId)
                .Select(x => new Follower
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    FollowerId = x.FollowerId
                })
                .ToListAsync();

            return followers;
        }

        public async Task<List<Follower>> GetFollowing(int followerId)
        {
            var following = await context.Followers.Where(x => x.FollowerId == followerId)
                .Select(x => new Follower
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    FollowerId = x.FollowerId
                })
                .ToListAsync();

            return following;
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
