using MovieNowAPI.Entities;

namespace MovieNowAPI.Repository
{
    public interface IProfilePrivacySettingRepository : IDisposable
    {
        Task<ProfilePrivacySetting> GetProfilePrivacySettingByUser(int userId);
        Task AddProfilePrivacySetting(ProfilePrivacySetting setting);
        Task UpdateProfilePrivacySetting(ProfilePrivacySetting setting);
        Task Save();
    }
}
