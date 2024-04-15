using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Models;

using Microsoft.Extensions.DependencyInjection;

namespace TestApi.Repositories
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly BoatsContext _context;

        public EquipmentRepository(BoatsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Equipment>> GetAll()
        {
            return await _context.Equipments.ToListAsync();
        }

        public async Task<Equipment> GetByIdEquipment(int id)
        {
            try
            {
                var Equipment = await _context.Equipments.FindAsync(id);

                if (Equipment == null)
                {
                    return NotFound();
                }

                return Equipment;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Equipment> AddEquipment(Equipment equipment)
        {
            _context.Equipments.Add(equipment);
            await _context.SaveChangesAsync();
            return equipment;
        }

        public async Task<bool> UpdateEquipment(Equipment equipment)
        {
            _context.Entry(equipment).State = EntityState.Modified;

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
        public async Task<bool> DeleteEquipment(int id)
        {
            var equipment = await _context.Equipments.FindAsync(id);
            if (equipment == null)
                return false;

            _context.Equipments.Remove(equipment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EquipmentExists(int id)
        {
            return await _context.Equipments.AnyAsync(e => e.Id == id);
        }

        private Equipment NotFound()
        {
            throw new NotImplementedException();
        }
    }
}
