using System.ComponentModel.DataAnnotations;

namespace BooknGo.Data.Models
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        public int EventId { get; set; }
        public int? UserId { get; set; } // Nullable to indicate if it's not yet purchased
        public DateTime PurchaseDate { get; set; }

        // Navigation properties
        public virtual EventDetail Event { get; set; }
        public virtual User User { get; set; }
    }
}
