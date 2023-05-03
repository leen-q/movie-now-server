using Microsoft.EntityFrameworkCore;
using MovieNowAPI.Entities;

namespace MovieNowAPI.Repository
{
    public class ProfilePrivacySettingRepository : IProfilePrivacySettingRepository
    {
        private MovienowDbContext context;

        public ProfilePrivacySettingRepository(MovienowDbContext context)
        {
            this.context = context;
        }

        public async Task<ProfilePrivacySetting> GetProfilePrivacySettingByUser(int userId)
        {
            var setting = await context.ProfilePrivacySettings.Select(
                x => new ProfilePrivacySetting
                {
                    Id = x.Id,
                    UserId = userId,
                    Private = x.Private,
                    FollowersOnly = x.FollowersOnly,
                    Public = x.Public
                })
                .FirstOrDefaultAsync(x => x.UserId == userId);

            return setting;
        }

        public async Task AddProfilePrivacySetting(ProfilePrivacySetting setting)
        {
            await context.ProfilePrivacySettings.AddAsync(setting);
        }

        public async Task UpdateProfilePrivacySetting(ProfilePrivacySetting setting)
        {
            context.Entry(setting).State = EntityState.Modified;
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
