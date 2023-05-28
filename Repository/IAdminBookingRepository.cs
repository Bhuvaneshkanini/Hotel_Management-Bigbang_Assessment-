using Hotel_Management_Bigbang_Assessment1_.Models;

namespace Hotel_Management_Bigbang_Assessment1_.Repository
{
    public interface IAdminBookingRepository
    {
        Task<IEnumerable<Booking>> GetBookings();
        Task<int> AddBooking(Booking book);

    }
}
