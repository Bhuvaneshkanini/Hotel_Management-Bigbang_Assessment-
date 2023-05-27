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


        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotelByLocation(string id)
        {
            var hotel = await _Booking.GetHotelByIdLocation(id);
            if (hotel == null)
                return NotFound();
            return Ok(hotel);
        }

        

    }
}
