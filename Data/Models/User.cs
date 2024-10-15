using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace BooknGo.Data.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        // Navigation property
        public virtual ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    }
}
