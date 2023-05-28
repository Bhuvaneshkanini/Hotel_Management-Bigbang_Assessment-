using Hotel_Management_Bigbang_Assessment1_.Models;
using Hotel_Management_Bigbang_Assessment1_.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management_Bigbang_Assessment1_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerBookingController : ControllerBase
    {
        private readonly IBookingRepository _Booking;

        public CustomerBookingController(IBookingRepository _Booking)
        {
            this._Booking = _Booking;
        }

        [HttpGet]
        public async Task<ActionResult<List<Hotel>>> GetHotels()
        {
            try { 
                var hotels = await _Booking.GetHotelsBook();
                return Ok(hotels);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet("hotels/location")]
        public async Task<ActionResult<Hotel>> GetHotelByLocation(string Location)
        {
            try { 
                var hotel = await _Booking.GetHotelByLocation(Location);
                if (hotel == null)
                    return NotFound();
                return Ok(hotel);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("hotels/amenities")]
        public async Task<ActionResult<Hotel>> GetHotelsByAmenities(string amenities)
        {
            try
            {
                var hotel = await _Booking.GetHotelsByAmenities(amenities);
                if (hotel == null)
                    return NotFound();
                return Ok(hotel);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{minPrice}/{maxPrice}")]
        public async Task<ActionResult<Hotel>> GetHotelsByAmenities(double minPrice, double maxPrice)
        {
            try
            {
                var hotel = await _Booking.GetHotelsByPrice(minPrice, maxPrice);
                if (hotel == null)
                    return NotFound();
                return Ok(hotel);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost]

        public async Task<ActionResult<Booking>> AddBooking(Booking Book)
        {
            try { 
                var newHotelId = await _Booking.AddBooking(Book);
                return Ok("Booked Sucessfully!");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





    }
}
