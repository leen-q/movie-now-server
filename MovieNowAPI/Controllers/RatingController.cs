using System;
using System.Net;
using MovieNowAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieNowAPI.Repository;

namespace MovieNowAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingController : ControllerBase
    {
        private IRatingRepository ratingRepository;

        public RatingController(IRatingRepository ratingRepository)
        {
            this.ratingRepository = ratingRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Rating>>> GetAllRatings()
        {
            return await ratingRepository.GetAllRatings();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rating>> GetRatingById(int id)
        {
            return await ratingRepository.GetRatingById(id);
        }

        [HttpGet("movieId/{id}")]
        public async Task<ActionResult<List<Rating>>> GetRatingsByMovie(int id)
        {
            return await ratingRepository.GetRatingsByMovie(id);
        }

        [HttpGet("userId/{id}")]
        public async Task<ActionResult<List<Rating>>> GetRatingsByUser(int id)
        {
            return await ratingRepository.GetRatingsByUser(id);
        }

        [HttpPost]
        public async Task AddRating(Rating rating)
        {
            await ratingRepository.AddRating(rating);
            await ratingRepository.Save();
        }

        [HttpPut]
        public async Task UpdateRating(Rating rating)
        {
            await ratingRepository.UpdateRating(rating);
            await ratingRepository.Save();
        }

        [HttpDelete("{id}")]
        public async Task DeleteRating(int id)
        {
            await ratingRepository.DeleteRating(id);
            await ratingRepository.Save();
        }
    }
}
