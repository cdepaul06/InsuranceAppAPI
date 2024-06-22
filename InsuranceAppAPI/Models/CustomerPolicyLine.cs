using System.ComponentModel.DataAnnotations;

namespace InsuranceAppAPI.Models
{
    public class CustomerPolicyLine
    {
        [Key]
        public int CustomerPolicyLineId { get; set; }
        public int CustomerPolicyId { get; set; }
        public List<Automobile>? Automobiles { get; set; } = new List<Automobile>();
        public List<Home>? Homes { get; set; } = new List<Home>();
        public List<Motorcycle>? Motorcycles { get; set; } = new List<Motorcycle>();

        public virtual CustomerPolicy? CustomerPolicy { get; set; }
    }
}
