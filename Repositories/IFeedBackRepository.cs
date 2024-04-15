using System.Collections.Generic;
using System.Threading.Tasks;
using TestApi.Models;

namespace TestApi.Repositories
{
    public interface IFeedBackRepository
    {
        Task<IEnumerable<FeedBack>> GetAll();
        Task<FeedBack> GetByIdFeedBack(int id);
        Task<FeedBack> AddFeedBack(FeedBack feedBack);
        Task<bool> UpdateFeedBack(FeedBack feedBack);
        Task<bool> DeleteFeedBack(int id);
        Task<bool> FeedBackExists(int id);
    }
}
