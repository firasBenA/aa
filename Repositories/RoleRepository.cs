using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Models;

using Microsoft.Extensions.DependencyInjection;

namespace TestApi.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly BoatsContext _context;

        public RoleRepository(BoatsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> GetByIdRole(int id)
        {
            try
            {
                var Role = await _context.Roles.FindAsync(id);

                if (Role == null)
                {
                    return NotFound();
                }

                return Role;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<Role> AddRole(Role Roles)
        {
            _context.Roles.Add(Roles);
            await _context.SaveChangesAsync();
            return Roles;
        }

        public async Task<bool> UpdateRole(Role Roles)
        {
            _context.Entry(Roles).State = EntityState.Modified;

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

        public async Task<bool> DeleteRole(int id)
        {
            var Role = await _context.Roles.FindAsync(id);
            if (Role == null)
                return false;

            _context.Roles.Remove(Role);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RoleExistsRole(int id)
        {
            return await _context.Roles.AnyAsync(e => e.Id == id);
        }


        private Role NotFound()
        {
            throw new NotImplementedException();
        }

    }
}
