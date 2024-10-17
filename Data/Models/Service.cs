using System.ComponentModel.DataAnnotations;

namespace BooknGo.Data.Models
{
    public class Service
    {
        [Key]
        public Guid ServiceId { get; set; }

        [Required]
        public string ServiceName { get; set; }

        [Required]
        public string Description { get; set; }

        public decimal Price { get; set; }

        // Relation: One Service can have many Bookings
        public ICollection<Booking> Bookings { get; set; }
    }
}
