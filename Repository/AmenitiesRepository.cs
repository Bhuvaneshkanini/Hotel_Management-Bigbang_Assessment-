using Hotel_Management_Bigbang_Assessment1_.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management_Bigbang_Assessment1_.Repository
{
    public class AmenitiesRepository:IAmenitiesRepository
    {
        private readonly HotelDbContext _dbContext;

        public AmenitiesRepository(HotelDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<IEnumerable<Amenities>> GetAmenities()
        {
            return await _dbContext.Amenities.ToListAsync();

        }

        public async Task<IEnumerable<Amenities>> GetAmenitiesId(int AmenitiesId)
        {
            return await _dbContext.Amenities.Where(a => a.Amenitiesid == AmenitiesId).ToListAsync();
        }

        public async Task<int> AddAmenities(Amenities amenities)
        {
            _dbContext.Amenities.Add(amenities);
            await _dbContext.SaveChangesAsync();
            return amenities.Amenitiesid;
        }

        public async Task UpdateAmenities(Amenities amenities)
        {

            _dbContext.Entry(amenities).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }


    }
}
