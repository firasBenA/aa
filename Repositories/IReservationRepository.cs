using System.Collections.Generic;
using System.Threading.Tasks;
using TestApi.Models;

namespace TestApi.Repositories
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetAll();
        Task<Reservation> GetByIdReservation(int id);
        Task<Reservation> AddReservation(Reservation user);
        Task<bool> UpdateReservation(Reservation user);
        Task<bool> DeleteReservation(int id);
        Task<bool> ReservationExists(int id);
    }
}
