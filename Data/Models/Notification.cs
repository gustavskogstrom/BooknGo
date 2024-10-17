using System.ComponentModel.DataAnnotations;

namespace BooknGo.Data.Models
{
    public class Notification
    {
        [Key]
        public Guid NotificationId { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime SentDate { get; set; }

        // Relation: Notifiering kan vara kopplad till en kund eller bokning
        public Guid? CustomerId { get; set; }
        public Customer Customer { get; set; }

        public Guid? BookingId { get; set; }
        public Booking Booking { get; set; }
    }

}
