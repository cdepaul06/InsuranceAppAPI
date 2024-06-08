using System.ComponentModel.DataAnnotations;

namespace InsuranceAppAPI.Models
{
    public class Automobile
    {
        [Key]
        public int AutomobileId { get; set; }
        public int CustomerPolicyLineId { get; set; }
        public int MSRP { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string VIN { get; set; }

        public virtual CustomerPolicyLine CustomerPolicyLine { get; set; }

    }
}
