using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestApi.Models;
using TestApi.Repositories;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationRepository _ReservationRepository;

        public ReservationController(IReservationRepository ReservationRepository)
        {
            _ReservationRepository = ReservationRepository;
        }

        // GET: api/Task
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetAll()
        {
            var reservation = await _ReservationRepository.GetAll();
            return Ok(reservation);
        }

        // GET: api/Task/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetByIdReservation(int id)
        {
            var reservation = await _ReservationRepository.GetByIdReservation(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return Ok(reservation);
        }

        // POST: api/Task
        [HttpPost]
        public async Task<ActionResult<Reservation>> AddReservation(Reservation reservation)
        {
            var newReservation = await _ReservationRepository.AddReservation(reservation);
            return CreatedAtAction(nameof(AddReservation), new { id = newReservation.Id }, newReservation);
        }

        // PUT: api/Task/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservation(int id, Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return BadRequest();
            }
            var result = await _ReservationRepository.UpdateReservation(reservation);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }


        // DELETE: api/Task/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id) 
        {
            var result = await _ReservationRepository.DeleteReservation(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}