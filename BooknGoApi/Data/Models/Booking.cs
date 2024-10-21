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
        public Guid UserId { get; set; }
        public Guid ResourceId { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Resource Resource { get; set; }
    }
}
