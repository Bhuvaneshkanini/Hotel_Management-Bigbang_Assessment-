using Hotel_Management_Bigbang_Assessment1_.Models;

namespace Hotel_Management_Bigbang_Assessment1_.Repository
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Hotel>> GetHotelsBook();
        Task<IEnumerable<Hotel>> GetHotelByLocation(string location);

        Task<IEnumerable<Hotel>> GetHotelsByAmenities(string amenities);

        Task<IEnumerable<Hotel>> GetHotelsByPrice(double min, double max);

        Task<int> AddBooking(Booking book);

        Task Deletebooking(int bookId);
    }
}
