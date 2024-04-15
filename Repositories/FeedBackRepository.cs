using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Models;

using Microsoft.Extensions.DependencyInjection;

namespace TestApi.Repositories
{
    public class FeedBackRepository : IFeedBackRepository
    {
        private readonly BoatsContext _context;

        public FeedBackRepository(BoatsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FeedBack>> GetAll()
        {
            return await _context.FeedBacks.ToListAsync();
        }

        public async Task<FeedBack> GetByIdFeedBack(int id)
        {
            try
            {
                var FeedBack = await _context.FeedBacks.FindAsync(id);

                if (FeedBack == null)
                {
                    return NotFound();
                }

                return FeedBack;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<FeedBack> AddFeedBack(FeedBack feedBack)
        {
            _context.FeedBacks.Add(feedBack);
            await _context.SaveChangesAsync();
            return feedBack;
        }

        public async Task<bool> UpdateFeedBack(FeedBack feedBack)
        {
            _context.Entry(feedBack).State = EntityState.Modified;

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
        public async Task<bool> DeleteFeedBack(int id)
        {
            var feedBack = await _context.FeedBacks.FindAsync(id);
            if (feedBack == null)
                return false;

            _context.FeedBacks.Remove(feedBack);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> FeedBackExists(int id)
        {
            return await _context.FeedBacks.AnyAsync(e => e.Id == id);
        }

        private FeedBack NotFound()
        {
            throw new NotImplementedException();
        }
    }
}
