using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestApi.Models;
using TestApi.Repositories;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _UserRepository;

        public UserController(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var users = await _UserRepository.GetAll();
            return Ok(users);
        }

        // GET: api/User
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetByIdUser(int id)
        {
            var user = await _UserRepository.GetByIdUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            var newUser = await _UserRepository.AddUser(user);
            return CreatedAtAction(nameof(AddUser), new { id = newUser.Id }, newUser);
        }

        // PUT: api/User
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            var result = await _UserRepository.UpdateUser(user);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }


        // DELETE: api/User
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id) 
        {
            var result = await _UserRepository.DeleteUser(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}