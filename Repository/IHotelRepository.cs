using Hotel_Management_Bigbang_Assessment1_.Models;

namespace Hotel_Management_Bigbang_Assessment1_.Repository
{
    public interface IHotelRepository
    {
        Task<IEnumerable<Hotel>> GetHotels();
        Task<IEnumerable<Hotel>> GetHotelById(int hotelId);
        Task<int> AddHotel(Hotel hotel);
        Task UpdateHotel(Hotel hotel);
        Task DeleteHotel(int hotelId);


    }
}
