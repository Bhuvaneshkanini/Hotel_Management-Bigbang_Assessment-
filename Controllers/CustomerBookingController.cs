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
            var hotels = await _Booking.GetHotelsBook();
            return Ok(hotels);
        }


        [HttpGet("hotels/location")]
        public async Task<ActionResult<Hotel>> GetHotelByLocation(string Location)
        {
            var hotel = await _Booking.GetHotelByLocation(Location);
            if (hotel == null)
                return NotFound();
            return Ok(hotel);
        }

        [HttpGet("hotels/amenities")]
        public async Task<ActionResult<Hotel>> GetHotelsByAmenities(string amenities)
        {
            var hotel = await _Booking.GetHotelsByAmenities(amenities);
            if (hotel == null)
                return NotFound();
            return Ok(hotel);
        }

        [HttpGet("{minPrice}/{maxPrice}")]
        public async Task<ActionResult<Hotel>> GetHotelsByAmenities(double minPrice, double maxPrice)
        {
            var hotel = await _Booking.GetHotelsByPrice(minPrice, maxPrice);
            if (hotel == null)
                return NotFound();
            return Ok(hotel);
        }



    }
}
