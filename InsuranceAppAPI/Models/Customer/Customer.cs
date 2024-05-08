using System.ComponentModel.DataAnnotations;

namespace InsuranceAppAPI.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [MaxLength(50)]
        public required string FirstName { get; set; }
        [MaxLength(50)]
        public required string LastName { get; set; }
        [MaxLength(50)]
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string Address { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required int Zip { get; set; }
    }
}
