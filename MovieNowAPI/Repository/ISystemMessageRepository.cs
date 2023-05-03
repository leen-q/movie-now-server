using MovieNowAPI.Entities;

namespace MovieNowAPI.Repository
{
    public interface ISystemMessageRepository : IDisposable
    {
        Task<SystemMessage> GetSystemMessageById(int id);
        Task<List<SystemMessage>> GetSystemMessagesByUser(int userId);
        Task AddSystemMessage(SystemMessage systemMessage);
        Task DeleteSystemMessage(int id);
        Task Save();
    }
}
