using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestApi.Models;
using TestApi.Repositories;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoatController : ControllerBase
    {
        private readonly IBoatRepository _BoatRepository;

        public BoatController(IBoatRepository BoatRepository)
        {
            _BoatRepository = BoatRepository;
        }

        // GET: api/Task
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Boat>>> GetAll()
        {
            var boat = await _BoatRepository.GetAll();
            return Ok(boat);
        }

        // GET: api/Task/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetByIdBoat(int id)
        {
            var boat = await _BoatRepository.GetByIdBoat(id);
            if (boat == null)
            {
                return NotFound();
            }
            return Ok(boat);
        }

        // POST: api/Task
        [HttpPost]
        public async Task<ActionResult<User>> AddBoat(Boat user)
        {
            var newboat = await _BoatRepository.AddBoat(user);
            return CreatedAtAction(nameof(AddBoat), new { id = newboat.Id }, newboat);
        }

        // PUT: api/Task/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBoat(int id, Boat boat)
        {
            if (id != boat.Id)
            {
                return BadRequest();
            }
            var result = await _BoatRepository.UpdateBoat(boat);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }


        // DELETE: api/Task/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id) 
        {
            var result = await _BoatRepository.DeleteBoat(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}