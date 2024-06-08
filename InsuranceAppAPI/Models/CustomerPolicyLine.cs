using System.ComponentModel.DataAnnotations;

namespace InsuranceAppAPI.Models
{
    public class CustomerPolicyLine
    {
        [Key]
        public int CustomerPolicyLineId { get; set; }
        public int CustomerPolicyId { get; set; }
        public List<Automobile> ?Automobiles { get; set; }
        public List<Home> ?Homes { get; set; }
        public List<Motorcycle> ?Motorcycles { get; set; }

        public virtual CustomerPolicy CustomerPolicy { get; set; }
    }
}
