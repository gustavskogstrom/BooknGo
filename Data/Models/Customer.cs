using System.ComponentModel.DataAnnotations;

namespace BooknGo.Data.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        // Relation: One Customer can have many Bookings
        public ICollection<Booking> Bookings { get; set; }
    }
}
