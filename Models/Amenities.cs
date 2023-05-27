using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_Bigbang_Assessment1_.Models
{
    public class Amenities
    {
        [Key]
        public int Amenitiesid { get; set; }

        public string? Description { get; set; }

        public ICollection<Hotel>? Hotels { get; set; }
    }
}
