using System.ComponentModel.DataAnnotations;

namespace BooknGoApi.Data.Models
{
    public class Resource
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public List<Availability> Availability { get; set; }

        // Navigation property
        public ICollection<Booking> Bookings { get; set; }
    }
}
