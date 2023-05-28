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

        public async Task<IEnumerable<Hotel>> GetHotelByLocation(string location)
        {
            return await _dbContext.Hotels.Where(h => h.Location == location).ToListAsync();
        }


        public async Task<IEnumerable<Hotel>> GetHotelsByAmenities(string amenities)
        {
            return await _dbContext.Hotels.Include(h => h.Rooms).Include(h => h.Amenities)
                .Where(h => h.Amenities != null && h.Amenities.Description !=null && 
                h.Amenities.Description.Contains(amenities)).ToListAsync();

        }

        public async Task<IEnumerable<Hotel>> GetHotelsByPrice(double min,double max)
        {
            var hotels = await _dbContext.Hotels.Include(a => a.Rooms).ToListAsync();

            var filteredHotels = hotels.Select(hotel =>
            {
                hotel.Rooms = hotel.Rooms?.Where(room => room.Price >= min && room.Price <= max).ToList();
                return hotel;
            });
            return filteredHotels;

        }

        public async Task<int> AddBooking(Booking book)
        {
            _dbContext.Bookings.Add(book);

            var room = await _dbContext.Rooms.FindAsync(book.RoomNo);
            if (room != null)
            {
                room.Availability = "No";
                _dbContext.Rooms.Update(room);
            }
            await _dbContext.SaveChangesAsync();
            return book.BookingId;

        }

        
    }
}
