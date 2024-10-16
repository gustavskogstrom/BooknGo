using System.ComponentModel.DataAnnotations;

namespace BooknGo.Data.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string Country { get; set; }

        // Relation: En kund kan ha flera adresser
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }

}
