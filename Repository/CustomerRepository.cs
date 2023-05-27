using Hotel_Management_Bigbang_Assessment1_.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management_Bigbang_Assessment1_.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly HotelDbContext _hotelDbContext;
        public CustomerRepository(HotelDbContext _hotelDbContext)
        {
            this._hotelDbContext = _hotelDbContext;
        }

        

        public async Task<IEnumerable<Hotel>> GetHotel()
        {
            return await _hotelDbContext.Hotels.Include(a => a.Rooms).ToListAsync();
        }

        public async Task<IEnumerable<Hotel>> GetHotelById(int hotelid)
        {
            return await _hotelDbContext.Hotels.Where(a => a.HotelId == hotelid).Include(b => b.Rooms).ToListAsync();

        }

        public async Task<IEnumerable<Hotel>> GetHotelByLocation(string hotelloc)
        {
            return await _hotelDbContext.Hotels.Where(a => a.Location == hotelloc).Include(b => b.Rooms).ToListAsync();

        }


    }
}
