using Hotel_Management_Bigbang_Assessment1_.Models;

namespace Hotel_Management_Bigbang_Assessment1_.Repository
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Hotel>> GetHotelsBook();
        Task<IEnumerable<Hotel>> GetHotelByIdLocation(string hotelId);

        Task<IEnumerable<Hotel>> GetHotelsByAmenities(string amenities);
    }
}
