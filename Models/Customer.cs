using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_Bigbang_Assessment1_.Models
{
    public class Customer
    {
        [Key] 
        public int CustId { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public ICollection<Booking>? Bookings { get; set; }

    }
}
