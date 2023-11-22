using System.ComponentModel.DataAnnotations;

namespace FullStackProject.Models
{
    public class Login
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public string UserPassword { get; set; }
        [Required]
        public long UserPhoneNumber { get; set; }
    }
}
