using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Models;

namespace TestApi.Repositories
{
    public class FactureRepository : IFactureRepository
    {
        private readonly BoatsContext _context;

        public FactureRepository(BoatsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Facture>> GetAll()
        {
            return await _context.Factures.ToListAsync();
        }

        public async Task<Facture> GetByIdFacture(int id)
        {
            try
            {
                var facture = await _context.Factures.FindAsync(id);

                if (facture == null)
                {
                    return NotFound();
                }

                return facture;
            }
            catch (Exception)
            {
                throw; // You may consider logging the exception before re-throwing it
            }
        }

        public async Task<Facture> AddFacture(Facture facture)
        {
            _context.Factures.Add(facture);
            await _context.SaveChangesAsync();
            return facture;
        }

        public async Task<bool> UpdateFacture(Facture facture)
        {
            _context.Entry(facture).State = EntityState.Modified;

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

        public async Task<bool> DeleteFacture(int id)
        {
            var facture = await _context.Factures.FindAsync(id);
            if (facture == null)
                return false;

            _context.Factures.Remove(facture);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> FactureExists(int id)
        {
            return await _context.Factures.AnyAsync(e => e.Id == id);
        }

        private Facture NotFound()
        {
            throw new NotImplementedException();
        }
    }
}
