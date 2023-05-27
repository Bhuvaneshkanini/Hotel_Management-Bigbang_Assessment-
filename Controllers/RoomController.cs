using Hotel_Management_Bigbang_Assessment1_.Models;
using Hotel_Management_Bigbang_Assessment1_.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management_Bigbang_Assessment1_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;

        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Room>>> GetRooms()
        {
            var rooms = await _roomRepository.GetRooms();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoomById(int id)
        {
            var room = await _roomRepository.GetRoomById(id);
            if (room == null)
                return NotFound();
            return Ok(room);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateRoom(Room room)
        {
            var newRoomId = await _roomRepository.CreateRoom(room);
            return CreatedAtAction(nameof(GetRoomById), new { id = newRoomId }, newRoomId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(int id, Room room)
        {
            if (id != room.RoomId)
                return BadRequest();

            await _roomRepository.UpdateRoom(room);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            await _roomRepository.DeleteRoom(id);
            return NoContent();
        }
    }
}
