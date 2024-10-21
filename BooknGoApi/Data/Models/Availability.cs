using System.ComponentModel.DataAnnotations;

namespace BooknGoApi.Data.Models
{
    public class Availability
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsAvailable { get; set; }

        // Foreign key
        public Guid ResourceId { get; set; }

        // Navigation property
        public Resource Resource { get; set; }
    }
}
