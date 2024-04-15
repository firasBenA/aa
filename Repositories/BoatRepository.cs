using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Models;

using Microsoft.Extensions.DependencyInjection;

namespace TestApi.Repositories
{
    public class BoatRepository : IBoatRepository
    {
        private readonly BoatsContext _context;

        public BoatRepository(BoatsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Boat>> GetAll()
        {
            return await _context.Boats.ToListAsync();
        }

        public async Task<Boat> GetByIdBoat(int id)
        {
            try
            {
                var boat = await _context.Boats.FindAsync(id);

                if (boat == null)
                {
                    return NotFound();
                }

                return boat;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Boat> AddBoat(Boat boat)
        {
            _context.Boats.Add(boat);
            await _context.SaveChangesAsync();
            return boat;
        }

        public async Task<bool> UpdateBoat(Boat boat)
        {
            _context.Entry(boat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }
        public async Task<bool> DeleteBoat(int id)
        {
            var boat = await _context.Boats.FindAsync(id);
            if (boat == null)
                return false;

            _context.Boats.Remove(boat);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> BoatExists(int id)
        {
            return await _context.Boats.AnyAsync(e => e.Id == id);
        }

        private Boat NotFound()
        {
            throw new NotImplementedException();
        }
    }
}
