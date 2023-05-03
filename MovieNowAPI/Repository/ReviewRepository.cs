using Microsoft.EntityFrameworkCore;
using MovieNowAPI.Entities;

namespace MovieNowAPI.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private MovienowDbContext context;

        public ReviewRepository(MovienowDbContext context)
        {
            this.context = context;
        }

        public async Task AddReview(Review review)
        {
            await context.Reviews.AddAsync(review);
        }

        public async Task DeleteReview(int id)
        {
            Review review = await context.Reviews.FindAsync(id);
            context.Reviews.Remove(review);
        }

        public async Task<List<Review>> GetAllReviews()
        {
            return await context.Reviews.ToListAsync();
        }

        public async Task<Review> GetReviewById(int id)
        {
            return await context.Reviews.FindAsync(id);
        }

        public async Task<List<Review>> GetReviewsByMovie(int movieId)
        {
            var reviews = await context.Reviews.Where(x => x.MovieId == movieId)
                .Select(x => new Review
                {
                    Id = x.Id,
                    MovieId = x.MovieId,
                    UserId = x.UserId,
                    ReviewText = x.ReviewText,
                })
                .ToListAsync();

            return reviews;
        }

        public async Task<List<Review>> GetReviewsByUser(int userId)
        {
            var reviews = await context.Reviews.Where(x => x.UserId == userId)
                .Select(x => new Review
                {
                    Id = x.Id,
                    MovieId = x.MovieId,
                    UserId = x.UserId,
                    ReviewText = x.ReviewText,
                })
                .ToListAsync();

            return reviews;
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
