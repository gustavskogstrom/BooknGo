using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BooknGo.Data.Models
{
    public class Booking
    {
        [Key]
        public Guid BookingId { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }

        public DateTime ServiceDate { get; set; }

        // Foreign key for Customer
        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }

        // Foreign key for Service
        [ForeignKey("Service")]
        public Guid ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
