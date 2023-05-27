using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_Bigbang_Assessment1_.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        public string? RoomNumber { get; set; }
        public int Price { get; set; }
        public string? Availability { get; set; }

        public int HotelId { get; set; }
        public Hotel? Hotel { get; set; }

        public ICollection<Booking>? Bookings { get; set; }
    }
}
