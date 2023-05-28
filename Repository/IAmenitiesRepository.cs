using Hotel_Management_Bigbang_Assessment1_.Models;

namespace Hotel_Management_Bigbang_Assessment1_.Repository
{
    public interface IAmenitiesRepository
    {
        Task<IEnumerable<Amenities>> GetAmenities();

        Task<IEnumerable<Amenities>> GetAmenitiesId(int AmenitiesId);

        Task<int> AddAmenities(Amenities amenities);

        Task UpdateAmenities(Amenities amenities);

    }
}
