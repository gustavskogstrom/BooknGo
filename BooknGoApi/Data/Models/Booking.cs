using System.ComponentModel.DataAnnotations;

namespace BooknGoApi.Data.Models
{
    public class Booking
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime BookingDate { get; set; }
        public string Status { get; set; }

        // Foreign keys
        public Guid CustomerId { get; set; }
        public Guid ResourceId { get; set; }

        // Navigation properties
        public Customer Customer { get; set; }
        public Resource Resource { get; set; }
    }
}
