using MovieNowAPI.Entities;

namespace MovieNowAPI.Repository
{
    public interface IFollowerRepository : IDisposable
    {
        Task<Follower> GetFollowerById(int id);
        Task<List<Follower>> GetFollowers(int userId);
        Task<List<Follower>> GetFollowing(int followerId);
        Task AddFollower(Follower follower);
        Task DeleteFollower(int id);
        Task Save();
    }
}
