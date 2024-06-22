namespace InsuranceAppAPI.Models
{
    public class Home
    {
        public int HomeId { get; set; }
        public int CustomerPolicyLineId { get; set; }
        public int YearBuilt { get; set; }
        public int SquareFootage { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int Zip { get; set; }

        public virtual CustomerPolicyLine? CustomerPolicyLine { get; set; }
    }
}
