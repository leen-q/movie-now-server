using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieNowAPI.Entities;
using MovieNowAPI.Repository;

namespace MovieNowAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilePrivacySettingController : ControllerBase
    {
        private IProfilePrivacySettingRepository profilePrivacySettingRepository;

        public ProfilePrivacySettingController(IProfilePrivacySettingRepository profilePrivacySettingRepository)
        {
            this.profilePrivacySettingRepository = profilePrivacySettingRepository;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<ProfilePrivacySetting>> GetProfilePrivacySettingByUser(int userId)
        {
            return await profilePrivacySettingRepository.GetProfilePrivacySettingByUser(userId);
        }

        [HttpPost]
        public async Task AddProfilePrivacySetting(ProfilePrivacySetting setting)
        {
            await profilePrivacySettingRepository.AddProfilePrivacySetting(setting);
            await profilePrivacySettingRepository.Save();
        }

        [HttpPut]
        public async Task UpdateProfilePrivacySetting(ProfilePrivacySetting setting)
        {
            await profilePrivacySettingRepository.UpdateProfilePrivacySetting(setting);
            await profilePrivacySettingRepository.Save();
        }
    }
}

