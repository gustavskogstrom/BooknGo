using System.ComponentModel.DataAnnotations;

namespace BooknGo.Data.Models
{
    public class EventDetail
    {
        [Key]
        public int EventId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        // Navigation property
        public virtual ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    }
}
