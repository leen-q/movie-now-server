using Microsoft.EntityFrameworkCore;
using MovieNowAPI.Entities;

namespace MovieNowAPI.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private MovienowDbContext context;

        public MovieRepository(MovienowDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Movie>> FilterMovies(string title, string genre, string year)
        {
            var movies = context.Movies.AsQueryable();

            if (!string.IsNullOrEmpty(title))
            {
                movies = movies.Where(x => x.Title.Contains(title));
            }

            if (!string.IsNullOrEmpty(genre))
            {
                var genres = genre.Split(',');

                foreach (string g in genres)
                {
                    movies = movies.Where(x => x.Genre.Contains(g));
                }
            }

            if (!string.IsNullOrEmpty(year))
            {
                movies = movies.Where(x => x.Year == year);
            }

            var filteredMovies = await movies
                .Select(x => new Movie
                {
                    Id = x.Id,
                    Title = x.Title,
                    Genre = x.Genre,
                    Poster = x.Poster,
                    Year = x.Year
                })
                .ToListAsync();

            return filteredMovies;
        }


        public async Task<List<Movie>> GetAllMovies()
        {
            return await context.Movies.ToListAsync();
        }

        public async Task<Movie> GetMovieById(int id)
        {
            return await context.Movies.FindAsync(id);
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
