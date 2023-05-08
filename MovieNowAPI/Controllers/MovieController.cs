using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieNowAPI.Entities;
using MovieNowAPI.Repository;

namespace MovieNowAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private IMovieRepository movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Movie>>> GetAllMovies()
        {
            return await movieRepository.GetAllMovies();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovieById(int id)
        {
            return await movieRepository.GetMovieById(id);
        }

        [HttpGet("filter")]
        public async Task<ActionResult<List<Movie>>> FilterMovies(string? title = null, string? genre = null, string? year = null)
        {
            return await movieRepository.FilterMovies(title, genre, year);
        }

        [HttpGet("recent")]
        public async Task<ActionResult<List<Movie>>> GetRecentMovies()
        {
            return await movieRepository.GetRecentMovies();
        }
    }
}

