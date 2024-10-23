using System.ComponentModel.DataAnnotations;

namespace BooknGoApi.Data.Models
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public DateTime CreatedDate { get; set; }

        // Navigation property
        public ICollection<Booking> Bookings { get; set; }
    }
}
