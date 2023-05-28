using Hotel_Management_Bigbang_Assessment1_.Models;
using Hotel_Management_Bigbang_Assessment1_.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management_Bigbang_Assessment1_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenitiesController : ControllerBase
    {
        private readonly IAmenitiesRepository _AmenitiesRepository;

        public AmenitiesController(IAmenitiesRepository _AmenitiesRepository)
        {
            this._AmenitiesRepository = _AmenitiesRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Hotel>>> GetAmenities()
        {
            var hotels = await _AmenitiesRepository.GetAmenities();
            return Ok(hotels);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetAmenitiesId(int id)
        {
            var hotel = await _AmenitiesRepository.GetAmenitiesId(id);
            if (hotel == null)
                return NotFound();
            return Ok(hotel);
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddAmenities(Amenities amenities)
        {
            var newHotelId = await _AmenitiesRepository.AddAmenities(amenities);

            return CreatedAtAction(nameof(AddAmenities), new { id = newHotelId }, newHotelId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotel(int id, Amenities amenities)
        {

            await _AmenitiesRepository.UpdateAmenities(amenities);
            return NoContent();
        }


    }
}
