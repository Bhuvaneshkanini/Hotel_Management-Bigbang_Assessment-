using Hotel_Management_Bigbang_Assessment1_.Authentication;
using Hotel_Management_Bigbang_Assessment1_.Models;
using Hotel_Management_Bigbang_Assessment1_.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management_Bigbang_Assessment1_.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
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
            try
            {
                var hotels = await _AmenitiesRepository.GetAmenities();
                return Ok(hotels);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetAmenitiesId(int id)
        {
            try
            {
                var hotel = await _AmenitiesRepository.GetAmenitiesId(id);
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
        public async Task<ActionResult<int>> AddAmenities(Amenities amenities)
        {
            try
            {
                var neamentiesId = await _AmenitiesRepository.AddAmenities(amenities);
                return Ok("New Amenities Added Sucessfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotel(int id, Amenities amenities)
        {
            try
            {
                await _AmenitiesRepository.UpdateAmenities(amenities);
                return Ok($"{id} Updated Sucessfully");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
