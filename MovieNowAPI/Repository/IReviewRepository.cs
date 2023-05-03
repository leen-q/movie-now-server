using MovieNowAPI.Entities;

namespace MovieNowAPI.Repository
{
    public interface IReviewRepository : IDisposable
    {
        Task<List<Review>> GetAllReviews();
        Task<Review> GetReviewById(int id);
        Task<List<Review>> GetReviewsByUser(int userId);
        Task<List<Review>> GetReviewsByMovie(int movieId);
        Task AddReview(Review review);
        Task DeleteReview(int id);
        Task Save();
    }
}
