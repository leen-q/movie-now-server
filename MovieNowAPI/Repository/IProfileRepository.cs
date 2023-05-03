using MovieNowAPI.Entities;

namespace MovieNowAPI.Repository
{
    public interface IProfileRepository : IDisposable
    {
        Task<Profile> GetProfileByUser(int userId);
        Task AddProfile(Profile profile);
        Task UpdateProfile(Profile profile);
        Task Save();
    }
}
