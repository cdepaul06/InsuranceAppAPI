using System.ComponentModel.DataAnnotations;

namespace InsuranceAppAPI.Models
{
    public class Automobile
    {
        [Key]
        public int AutomobileId { get; set; }
        public int CustomerPolicyLineId { get; set; }
        public int MSRP { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }
        public string? VIN { get; set; }

        public virtual CustomerPolicyLine? CustomerPolicyLine { get; set; }

    }
}
