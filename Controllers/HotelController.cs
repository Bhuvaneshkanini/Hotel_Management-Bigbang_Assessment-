using Hotel_Management_Bigbang_Assessment1_.Models;
using Hotel_Management_Bigbang_Assessment1_.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management_Bigbang_Assessment1_.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Hotel>>> GetHotels()
        {
            var hotels = await _hotelRepository.GetHotels();
            return Ok(hotels);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotelById(int id)
        {
            var hotel = await _hotelRepository.GetHotelById(id);
            if (hotel == null)
                return NotFound();
            return Ok(hotel);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateHotel(Hotel hotel)
        {
            var newHotelId = await _hotelRepository.AddHotel(hotel);

            return CreatedAtAction(nameof(GetHotelById), new { id = newHotelId }, newHotelId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotel(int id, Hotel hotel)
        {
            
            await _hotelRepository.UpdateHotel(hotel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            await _hotelRepository.DeleteHotel(id);
            return NoContent();
        }


    }
}
