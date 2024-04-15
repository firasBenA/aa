using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestApi.Models;
using TestApi.Repositories;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatRepository _ChatRepository;

        public ChatController(IChatRepository ChatRepository)
        {
            _ChatRepository = ChatRepository;
        }

        // GET: api/Task
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chat>>> GetAll()
        {
            var Chat = await _ChatRepository.GetAll();
            return Ok(Chat);
        }

        // GET: api/Task/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetByIdReservation(int id)
        {
            var Chat = await _ChatRepository.GetByIdChat(id);
            if (Chat == null)
            {
                return NotFound();
            }
            return Ok(Chat);
        }

        // POST: api/Task
        [HttpPost]
        public async Task<ActionResult<Chat>> AddChat(Chat chat)
        {
            var newChat = await _ChatRepository.AddChat(chat);
            return CreatedAtAction(nameof(AddChat), new { id = newChat.Id }, newChat);
        }

        // PUT: api/Task/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateChat(int id, Chat chat)
        {
            if (id != chat.Id)
            {
                return BadRequest();
            }
            var result = await _ChatRepository.UpdateChat(chat);
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
            var result = await _ChatRepository.DeleteChat(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}