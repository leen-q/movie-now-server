using Microsoft.EntityFrameworkCore;
using MovieNowAPI.Entities;

namespace MovieNowAPI.Repository
{
    public class ProfileRepository : IProfileRepository
    {
        private MovienowDbContext context;

        public ProfileRepository(MovienowDbContext context)
        {
            this.context = context;
        }

        public async Task<Profile> GetProfileByUser(int userId)
        {
            var profile = await context.Profiles.Select(
                x => new Profile
                {
                    Id = x.Id,
                    UserId = userId,
                    Name = x.Name,
                    Surname = x.Surname,
                    Gender = x.Gender
                })
                .FirstOrDefaultAsync(x => x.UserId == userId);

            return profile;
        }

        public async Task AddProfile(Profile profile)
        {
            await context.Profiles.AddAsync(profile);
        }

        public async Task UpdateProfile(Profile profile)
        {
            context.Entry(profile).State = EntityState.Modified;
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
