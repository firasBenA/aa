using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Models;

using Microsoft.Extensions.DependencyInjection;

namespace TestApi.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly BoatsContext _context;

        public ChatRepository(BoatsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Chat>> GetAll()
        {
            return await _context.Chats.ToListAsync();
        }

        public async Task<Chat> GetByIdChat(int id)
        {
            try
            {
                var Chat = await _context.Chats.FindAsync(id);

                if (Chat == null)
                {
                    return NotFound();
                }

                return Chat;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Chat> AddChat(Chat chat)
        {
            _context.Chats.Add(chat);
            await _context.SaveChangesAsync();
            return chat;
        }

        public async Task<bool> UpdateChat(Chat chat)
        {
            _context.Entry(chat).State = EntityState.Modified;

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
        public async Task<bool> DeleteChat(int id)
        {
            var chat = await _context.Chats.FindAsync(id);
            if (chat == null)
                return false;

            _context.Chats.Remove(chat);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ChatExists(int id)
        {
            return await _context.Chats.AnyAsync(e => e.Id == id);
        }

        private Chat NotFound()
        {
            throw new NotImplementedException();
        }
    }
}
