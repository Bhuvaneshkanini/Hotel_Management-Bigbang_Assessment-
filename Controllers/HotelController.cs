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
            try
            {
                var hotels = await _hotelRepository.GetHotels();
                return Ok(hotels);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotelById(int id)
        {
            try
            {
                var hotel = await _hotelRepository.GetHotelById(id);
                if (hotel == null)
                    return NotFound();
                return Ok(hotel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateHotel(Hotel hotel)
        {
            try
            {
                var newHotelId = await _hotelRepository.AddHotel(hotel);
                return Ok("Hotel Created sucessFully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotel(int id, Hotel hotel)
        {
            try { 
                await _hotelRepository.UpdateHotel(hotel);
                return Ok($"{id} Updated Sucessfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            try { 
                await _hotelRepository.DeleteHotel(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
