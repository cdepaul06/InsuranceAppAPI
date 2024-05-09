using System.ComponentModel.DataAnnotations;

namespace InsuranceAppAPI.Models
{
#nullable disable
    public class User
    {

        [Key]
        public int UserId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime LastLogin { get; set; }
        [Required]
        public int UserStatusId { get; set; }

        public virtual UserStatus UserStatus { get; set; }
    }
}
