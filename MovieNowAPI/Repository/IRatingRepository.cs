using MovieNowAPI.Entities;

namespace MovieNowAPI.Repository
{
    public interface IRatingRepository : IDisposable
    {
        Task<List<Rating>> GetAllRatings();
        Task<Rating> GetRatingById(int id);
        Task<List<Rating>> GetRatingsByUser(int userId);
        Task<List<Rating>> GetRatingsByMovie(int movieId);
        Task AddRating(Rating rating);
        Task UpdateRating(Rating rating);
        Task DeleteRating(int id);
        Task Save();
    }
}
