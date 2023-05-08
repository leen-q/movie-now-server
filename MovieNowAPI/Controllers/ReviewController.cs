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
    public class ReviewController : ControllerBase
    {
        private IReviewRepository reviewRepository;

        public ReviewController(IReviewRepository reviewRepository)
        {
            this.reviewRepository = reviewRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Review>>> GetAllReviews()
        {
            return await reviewRepository.GetAllReviews();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReviewById(int id)
        {
            return await reviewRepository.GetReviewById(id);
        }

        [HttpGet("movieId/{id}")]
        public async Task<ActionResult<List<Review>>> GetReviewsByMovie(int id)
        {
            return await reviewRepository.GetReviewsByMovie(id);
        }

        [HttpGet("userId/{id}")]
        public async Task<ActionResult<List<Review>>> GetReviewsByUser(int id)
        {
            return await reviewRepository.GetReviewsByUser(id);
        }

        [HttpPost]
        public async Task AddReview(Review review)
        {
            await reviewRepository.AddReview(review);
            await reviewRepository.Save();
        }

        [HttpDelete("{id}")]
        public async Task DeleteReview(int id)
        {
            await reviewRepository.DeleteReview(id);
            await reviewRepository.Save();
        }
    }
}
