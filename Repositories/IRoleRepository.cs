using System.Collections.Generic;
using System.Threading.Tasks;
using TestApi.Models;

namespace TestApi.Repositories
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAll();
        Task<Role> GetByIdRole(int id);
        Task<Role> AddRole(Role Roles);
        Task<bool> UpdateRole(Role Roles);
        Task<bool> DeleteRole(int id);
        Task<bool> RoleExistsRole(int id);
    }
}
