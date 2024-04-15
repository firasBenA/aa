using System.Collections.Generic;
using System.Threading.Tasks;
using TestApi.Models;

namespace TestApi.Repositories
{
    public interface IBoatRepository
    {
        Task<IEnumerable<Boat>> GetAll();
        Task<Boat> GetByIdBoat(int id);
        Task<Boat> AddBoat(Boat boat);
        Task<bool> UpdateBoat(Boat boat);
        Task<bool> DeleteBoat(int id);
        Task<bool> BoatExists(int id);
    }
}
