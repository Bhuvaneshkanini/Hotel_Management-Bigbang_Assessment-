using Hotel_Management_Bigbang_Assessment1_.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management_Bigbang_Assessment1_.Repository
{
    public class BookingRepository:IBookingRepository
    {
        private readonly HotelDbContext _dbContext;

        public BookingRepository(HotelDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<IEnumerable<Hotel>> GetHotelsBook()
        {
            return await _dbContext.Hotels.Include(b => b.Rooms).ToListAsync();

        }

        public async Task<IEnumerable<Hotel>> GetHotelByIdLocation(string hotelId)
        {
            return await _dbContext.Hotels.Where(a => a.Location == hotelId).Include(b => b.Rooms).ToListAsync();
        }

        public async Task<IEnumerable<Hotel>> GetHotelsByAmenities(string amenities)
        {
            
            return await _dbContext.Hotels.Include(a=>a.Rooms).Include(b=>b.Amenities).ToListAsync();
        }

        

    }
}
