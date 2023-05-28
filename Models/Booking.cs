using Hotel_Management_Bigbang_Assessment1_.Authentication;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Management_Bigbang_Assessment1_.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        public string? Username { get; set; }

        public int RoomNo { get; set; }
        public Room? Room { get; set; }

        public int HotelId { get; set; }
        public Hotel? Hotel { get; set; }

    }
}
