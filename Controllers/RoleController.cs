using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestApi.Models;
using TestApi.Repositories;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _RoleRepository;

        public RoleController(IRoleRepository RoleRepository)
        {
            _RoleRepository = RoleRepository;
        }

        // GET: api/Task
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetAll()
        {
            var roles = await _RoleRepository.GetAll();
            return Ok(roles);
        }

        // GET: api/Task/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetByIdRoles(int id)
        {
            var role = await _RoleRepository.GetByIdRole(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        // POST: api/Task
        [HttpPost]
        public async Task<ActionResult<Role>> AddRole(Role Role)
        {
            var newRole = await _RoleRepository.AddRole(Role);
            return CreatedAtAction(nameof(AddRole), new { id = newRole.Id }, newRole);
        }

        // PUT: api/Task/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(int id, Role Role)
        {
            if (id != Role.Id)
            {
                return BadRequest();
            }
            var role = await _RoleRepository.UpdateRole(Role);
            if (!role)
            {
                return NotFound();
            }
            return NoContent();
        }


        // DELETE: api/Task/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id) 
        {
            var role = await _RoleRepository.DeleteRole(id);
            if (!role)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}