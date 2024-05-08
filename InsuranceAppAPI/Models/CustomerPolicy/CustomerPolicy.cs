using System.ComponentModel.DataAnnotations;

namespace InsuranceAppAPI.Models
{
    public class CustomerPolicy
    {
        [Key]
        public int CustomerPolicyId { get; set; }
        public int CustomerId { get; set; }
        public int PolicyId { get; set; }
        public DateTime PolicyStartDate { get; set; }
        public DateTime PolicyEndDate { get; set; }
        public decimal PolicyPremium { get; set; }
        public int PolicyTypeId { get; set; }
        public int PolicyStatusId { get; set; }

        public virtual required Customer Customer { get; set; }
        public virtual required PolicyStatus PolicyStatus { get; set; }
        
    }
}