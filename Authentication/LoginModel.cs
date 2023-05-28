using Hotel_Management_Bigbang_Assessment1_.Models;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_Bigbang_Assessment1_.Authentication
{
    public class LoginModel
    {
        [Key]

        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        public ICollection<Booking>? Bookings { get; set; }
    }
}
