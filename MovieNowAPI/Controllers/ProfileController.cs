using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieNowAPI.Entities;
using MovieNowAPI.Repository;

namespace MovieNowAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private IProfileRepository profileRepository;

        public ProfileController(IProfileRepository profileRepository)
        {
            this.profileRepository = profileRepository;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<Profile>> GetProfileByUser(int userId)
        {
            return await profileRepository.GetProfileByUser(userId);
        }

        [HttpPost]
        public async Task AddProfile(Profile profile)
        {
            await profileRepository.AddProfile(profile);
            await profileRepository.Save();
        }

        [HttpPut]
        public async Task UpdateProfile(Profile profile)
        {
            await profileRepository.UpdateProfile(profile);
            await profileRepository.Save();
        }
    }
}

