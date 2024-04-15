using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestApi.Models;
using TestApi.Repositories;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentRepository _EquipmentRepository;

        public EquipmentController(IEquipmentRepository EquipmentRepository)
        {
            _EquipmentRepository = EquipmentRepository;
        }

        // GET: api/Task
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipment>>> GetAll()
        {
            var equipment = await _EquipmentRepository.GetAll();
            return Ok(equipment);
        }

        // GET: api/Task/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetByIdREquipment(int id)
        {
            var equipment = await _EquipmentRepository.GetByIdEquipment(id);
            if (equipment == null)
            {
                return NotFound();
            }
            return Ok(equipment);
        }

        // POST: api/Task
        [HttpPost]
        public async Task<ActionResult<Equipment>> AddEquipment(Equipment reservation)
        {
            var newEquipment = await _EquipmentRepository.AddEquipment(reservation);
            return CreatedAtAction(nameof(AddEquipment), new { id = newEquipment.Id }, newEquipment);
        }

        // PUT: api/Task/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEquipment(int id, Equipment equipment)
        {
            if (id != equipment.Id)
            {
                return BadRequest();
            }
            var result = await _EquipmentRepository.UpdateEquipment(equipment);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }


        // DELETE: api/Task/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipment(int id) 
        {
            var result = await _EquipmentRepository.DeleteEquipment(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}