using System.ComponentModel.DataAnnotations;

namespace BooknGo.Data.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; } // Lagra lösenord som hash

        public string Role { get; set; } // Exempel: Admin, Customer

        // En användare kan vara kopplad till en kund
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
