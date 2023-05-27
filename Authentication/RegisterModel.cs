using Hotel_Management_Bigbang_Assessment1_.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_Bigbang_Assessment1_.Authentication
{
    public class RegisterModel
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        public ICollection<Booking>? Bookings { get; set; }
    }
}
