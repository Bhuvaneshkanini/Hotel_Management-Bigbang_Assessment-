using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_Bigbang_Assessment1_.Models
{
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }
        public string? Country { get; set; }
        public string? Location { get; set; }

        public int Amenitiesid { get; set; }

        public Amenities? Amenities { get; set; }
        public ICollection<Room>? Rooms { get; set; }

        public ICollection<Booking>? Bookings { get; set; }
    }
}
