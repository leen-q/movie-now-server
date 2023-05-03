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

        [HttpGet("{movieId}")]
        public async Task<ActionResult<List<Review>>> GetReviewsByMovie(int movieId)
        {
            return await reviewRepository.GetReviewsByMovie(movieId);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<List<Review>>> GetReviewsByUser(int userId)
        {
            return await reviewRepository.GetReviewsByUser(userId);
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
