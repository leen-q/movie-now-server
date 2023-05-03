using Microsoft.EntityFrameworkCore;
using MovieNowAPI.Entities;

namespace MovieNowAPI.Repository
{
    public class SystemMessageRepository : ISystemMessageRepository
    {
        private MovienowDbContext context;

        public SystemMessageRepository(MovienowDbContext context)
        {
            this.context = context;
        }
        public async Task AddSystemMessage(SystemMessage systemMessage)
        {
            await context.SystemMessages.AddAsync(systemMessage);
        }

        public async Task DeleteSystemMessage(int id)
        {
            SystemMessage systemMessage = await context.SystemMessages.FindAsync(id);
            context.SystemMessages.Remove(systemMessage);
        }

        public async Task<SystemMessage> GetSystemMessageById(int id)
        {
            return await context.SystemMessages.FindAsync(id);
        }

        public async Task<List<SystemMessage>> GetSystemMessagesByUser(int userId)
        {
            var systemMessages = await context.SystemMessages.Where(x => x.UserId == userId)
                .Select(x => new SystemMessage
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    Text = x.Text
                })
                .ToListAsync();

            return systemMessages;
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
