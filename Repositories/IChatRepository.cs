using System.Collections.Generic;
using System.Threading.Tasks;
using TestApi.Models;

namespace TestApi.Repositories
{
    public interface IChatRepository
    {
        Task<IEnumerable<Chat>> GetAll();
        Task<Chat> GetByIdChat(int id);
        Task<Chat> AddChat(Chat boat);
        Task<bool> UpdateChat(Chat boat);
        Task<bool> DeleteChat(int id);
        Task<bool> ChatExists(int id);
    }
}
