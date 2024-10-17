using System.ComponentModel.DataAnnotations;

namespace BooknGo.Data.Models
{
    public class ServiceCategory
    {
        [Key]
        public Guid CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public string Description { get; set; }

        // Relation: En kategori kan ha flera tjänster
        public ICollection<Service> Services { get; set; }
    }

}
