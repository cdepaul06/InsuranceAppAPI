using System.ComponentModel.DataAnnotations;

namespace InsuranceAppAPI.Models
{
    public class PolicyType
    {
        [Key]
        public int PolicyTypeId { get; set; }
        public required string PolicyTypeName { get; set; }
        public required string PolicyTypeDescription { get; set;}
    }
}
