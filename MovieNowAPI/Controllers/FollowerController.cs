using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieNowAPI.Entities;
using MovieNowAPI.Repository;

namespace MovieNowAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FollowerController : ControllerBase
    {
        private IFollowerRepository followerRepository;

        public FollowerController(IFollowerRepository followerRepository)
        {
            this.followerRepository = followerRepository;
        }

        [HttpGet("followers/{userId}")]
        public async Task<ActionResult<List<Follower>>> GetFollowers(int userId)
        {
            return await followerRepository.GetFollowers(userId);
        }

        [HttpGet("following/{followerId}")]
        public async Task<ActionResult<List<Follower>>> GetFollowing(int followerId)
        {
            return await followerRepository.GetFollowing(followerId);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Follower>> GetFollowerById(int id)
        {
            return await followerRepository.GetFollowerById(id);
        }

        [HttpPost]
        public async Task AddFollower(Follower follower)
        {
            await followerRepository.AddFollower(follower);
            await followerRepository.Save();
        }

        [HttpDelete("{id}")]
        public async Task DeleteFollower(int id)
        {
            await followerRepository.DeleteFollower(id);
            await followerRepository.Save();
        }
    }
}

