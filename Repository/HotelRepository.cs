using Hotel_Management_Bigbang_Assessment1_.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management_Bigbang_Assessment1_.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelDbContext _dbContext;

        public HotelRepository(HotelDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<IEnumerable<Hotel>> GetHotels()
        {
            return await _dbContext.Hotels.Include(b => b.Rooms).ToListAsync();

        }

        public async Task<IEnumerable<Hotel>> GetHotelById(int hotelId)
        {
            return await _dbContext.Hotels.Where(a => a.HotelId == hotelId).Include(b => b.Rooms).ToListAsync();
        }

        public async Task<int> AddHotel(Hotel hotel)
        {
            _dbContext.Hotels.Add(hotel);
            await _dbContext.SaveChangesAsync();
            return hotel.HotelId;
        }

        public async Task UpdateHotel(Hotel hotel)
        {

            _dbContext.Entry(hotel).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteHotel(int hotelId)
        {
            var hotel = await _dbContext.Hotels.FindAsync(hotelId);
            if (hotel != null)
            {
                _dbContext.Hotels.Remove(hotel);
                await _dbContext.SaveChangesAsync();
            }
        }

    }
}
