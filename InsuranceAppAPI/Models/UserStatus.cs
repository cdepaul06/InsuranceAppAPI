using System.ComponentModel.DataAnnotations;

namespace InsuranceAppAPI.Models
{
    public class UserStatus
    {
        [Key]
        public int UserStatusId { get; set; }
        public required string UserStatusName { get; set; }
        public required string UserStatusDescription { get; set; }
    }
}
