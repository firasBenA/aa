using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestApi.Models;
using TestApi.Repositories;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBackController : ControllerBase
    {
        private readonly IFeedBackRepository _FeedBackRepository;

        public FeedBackController(IFeedBackRepository FeedBackRepository)
        {
            _FeedBackRepository = FeedBackRepository;
        }

        // GET: api/Task
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedBack>>> GetAll()
        {
            var feedBack = await _FeedBackRepository.GetAll();
            return Ok(feedBack);
        }

        // GET: api/Task/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FeedBack>> GetByIdFeedBack(int id)
        {
            var feedBackfeedBack = await _FeedBackRepository.GetByIdFeedBack(id);
            if (feedBackfeedBack == null)
            {
                return NotFound();
            }
            return Ok(feedBackfeedBack);
        }

        // POST: api/Task
        [HttpPost]
        public async Task<ActionResult<FeedBack>> AddFeedBack(FeedBack feedBack)
        {
            var newfeedBack = await _FeedBackRepository.AddFeedBack(feedBack);
            return CreatedAtAction(nameof(AddFeedBack), new { id = newfeedBack.Id }, newfeedBack);
        }

        // PUT: api/Task/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFeedBack(int id, FeedBack feedBack)
        {
            if (id != feedBack.Id)
            {
                return BadRequest();
            }
            var result = await _FeedBackRepository.UpdateFeedBack(feedBack);
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
            var result = await _FeedBackRepository.DeleteFeedBack(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}