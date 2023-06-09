﻿using Hotel_Management_Bigbang_Assessment1_.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management_Bigbang_Assessment1_.Repository
{
    public class AdminBookingRepository:IAdminBookingRepository
    {
        private readonly HotelDbContext _dbContext;

        public AdminBookingRepository(HotelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Booking>> GetBookings()
        {
            return await _dbContext.Bookings.ToListAsync();

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

