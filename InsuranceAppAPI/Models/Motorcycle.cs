namespace InsuranceAppAPI.Models
{
    public class Motorcycle
    {
        public int MotorcycleId { get; set; }
        public int CustomerPolicyLineId { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string VIN { get; set; }

        public virtual CustomerPolicyLine CustomerPolicyLine { get; set; }
    }
}
