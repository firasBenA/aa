using System.Collections.Generic;
using System.Threading.Tasks;
using TestApi.Models;

namespace TestApi.Repositories
{
    public interface IFactureRepository
    {
        Task<IEnumerable<Facture>> GetAll();
        Task<Facture> GetByIdFacture(int id);
        Task<Facture> AddFacture(Facture facture);
        Task<bool> UpdateFacture(Facture facture);
        Task<bool> DeleteFacture(int id);
        Task<bool> FactureExists(int id);
    }
}
