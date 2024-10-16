using System.ComponentModel.DataAnnotations;

namespace BooknGo.Data.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }

        [Required]
        public int Rating { get; set; } // Exempel: 1-5 stjärnor

        public string Comment { get; set; }

        // Relation: Feedback är kopplad till en specifik bokning
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
    }

}
