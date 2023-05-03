using Microsoft.EntityFrameworkCore;
using MovieNowAPI.Entities;

namespace MovieNowAPI.Repository
{
    public class RatingRepository : IRatingRepository
    {
        private MovienowDbContext context;

        public RatingRepository(MovienowDbContext context)
        {
            this.context = context;
        }

        public async Task AddRating(Rating rating)
        {
            await context.Ratings.AddAsync(rating);
        }

        public async Task DeleteRating(int id)
        {
            Rating rating = await context.Ratings.FindAsync(id);
            context.Ratings.Remove(rating);
        }

        public async Task<List<Rating>> GetAllRatings()
        {
            return await context.Ratings.ToListAsync();
        }

        public async Task<Rating> GetRatingById(int id)
        {
            return await context.Ratings.FindAsync(id);
        }

        public async Task<List<Rating>> GetRatingsByMovie(int movieId)
        {
            var ratings = await context.Ratings.Where(x => x.MovieId == movieId)
                .Select(x => new Rating
                {
                    Id = x.Id,
                    MovieId = x.MovieId,
                    UserId = x.UserId,
                    RatingNumber = x.RatingNumber
                })
                .ToListAsync();

            return ratings;
        }

        public async Task<List<Rating>> GetRatingsByUser(int userId)
        {
            var ratings = await context.Ratings.Where(x => x.UserId == userId)
                .Select(x => new Rating
                {
                    Id = x.Id,
                    MovieId = x.MovieId,
                    UserId = x.UserId,
                    RatingNumber = x.RatingNumber
                })
                .ToListAsync();

            return ratings;
        }

        public async Task UpdateRating(Rating rating)
        {
            context.Entry(rating).State = EntityState.Modified;
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
