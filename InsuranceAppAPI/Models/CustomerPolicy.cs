using System.ComponentModel.DataAnnotations;

namespace InsuranceAppAPI.Models
{
#nullable disable
    public class CustomerPolicy
    {
        [Key]
        public int CustomerPolicyId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public int PolicyId { get; set; }
        public DateTime PolicyStartDate { get; set; }
        public DateTime PolicyEndDate { get; set; }
        public decimal PolicyPremium { get; set; }
        [Required]
        public int PolicyTypeId { get; set; }
        [Required]
        public int PolicyStatusId { get; set; }


        public virtual Customer Customer { get; set; }
        public virtual PolicyStatus PolicyStatus { get; set; }
        
    }
}