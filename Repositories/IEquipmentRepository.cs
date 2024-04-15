using System.Collections.Generic;
using System.Threading.Tasks;
using TestApi.Models;

namespace TestApi.Repositories
{
    public interface IEquipmentRepository
    {
        Task<IEnumerable<Equipment>> GetAll();
        Task<Equipment> GetByIdEquipment(int id);
        Task<Equipment> AddEquipment(Equipment boat);
        Task<bool> UpdateEquipment(Equipment boat);
        Task<bool> DeleteEquipment(int id);
        Task<bool> EquipmentExists(int id);
    }
}
