using System.ComponentModel.DataAnnotations;

namespace InsuranceAppAPI.Models
{
#nullable disable
    public class User
    {

        [Key]
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime LastLogin { get; set; }
        public int UserStatusId { get; set; }
        public int UserTypeId { get; set; }

        public virtual UserStatus UserStatus { get; set; }
        public virtual UserType UserType { get; set; }
    }
}
