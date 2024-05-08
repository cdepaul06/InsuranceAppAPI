namespace InsuranceAppAPI.Models
{
    public class PolicyStatus
    {
        public int PolicyStatusId { get; set; }
        public required string PolicyStatusName { get; set; }
        public required string PolicyStatusDescription { get; set;}
    }
}
