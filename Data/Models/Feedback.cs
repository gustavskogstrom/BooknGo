using System.ComponentModel.DataAnnotations;

namespace BooknGo.Data.Models
{
    public class Feedback
    {
        [Key]
        public Guid FeedbackId { get; set; }

        [Required]
        public int Rating { get; set; } // Exempel: 1-5 stjärnor

        public string Comment { get; set; }

        // Relation: Feedback är kopplad till en specifik bokning
        public Guid BookingId { get; set; }
        public Booking Booking { get; set; }
    }

}
