using System.ComponentModel.DataAnnotations;

namespace InsuranceAppAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required DateTime LastLogin { get; set; }
        public required int UserStatusId { get; set; }

        public virtual required UserStatus UserStatus { get; set; }

    }
}
