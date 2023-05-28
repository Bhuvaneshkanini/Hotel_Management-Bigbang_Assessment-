using Hotel_Management_Bigbang_Assessment1_.Models;
using Hotel_Management_Bigbang_Assessment1_.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management_Bigbang_Assessment1_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminBookingsController : ControllerBase
    {
        private readonly IAdminBookingRepository _Booking;

        public AdminBookingsController(IAdminBookingRepository _Booking)
        {
            this._Booking = _Booking;
        }

        [HttpGet]
        public async Task<ActionResult<List<Hotel>>> GetHotels()
        {
            try
            {
                var hotels = await _Booking.GetBookings();
                return Ok(hotels);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]

        public async Task<ActionResult<Booking>> AddBooking(Booking Book)
        {
            try
            {
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
