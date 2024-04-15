using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestApi.Models;
using TestApi.Repositories;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactureController : ControllerBase
    {
        private readonly IFactureRepository _FactureRepository;

        public FactureController(IFactureRepository FactureRepository)
        {
            _FactureRepository = FactureRepository;
        }

        // GET: api/Task
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Facture>>> GetAll()
        {
            var facture = await _FactureRepository.GetAll();
            return Ok(facture);
        }

        // GET: api/Task/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetByIdFacture(int id)
        {
            var facture = await _FactureRepository.GetByIdFacture(id);
            if (facture == null)
            {
                return NotFound();
            }
            return Ok(facture);
        }

        // POST: api/Task
        [HttpPost]
        public async Task<ActionResult<Facture>> AddFacture(Facture facture)
        {
            var newfacture = await _FactureRepository.AddFacture(facture);
            return CreatedAtAction(nameof(AddFacture), new { id = newfacture.Id }, newfacture);
        }

        // PUT: api/Task/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFacture(int id, Facture facture)
        {
            if (id != facture.Id)
            {
                return BadRequest();
            }
            var result = await _FactureRepository.UpdateFacture(facture);
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
            var result = await _FactureRepository.DeleteFacture(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}