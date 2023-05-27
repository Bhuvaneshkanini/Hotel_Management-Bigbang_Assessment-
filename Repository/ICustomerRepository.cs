using Hotel_Management_Bigbang_Assessment1_.Models;

namespace Hotel_Management_Bigbang_Assessment1_.Repository
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Hotel>> GetHotel();
        Task<IEnumerable<Hotel>> GetHotelById(int hotelId);

        Task<IEnumerable<Hotel>> GetHotelByLocation(string hotelloc);
    }
}
