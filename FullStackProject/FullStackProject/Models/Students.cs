using System.ComponentModel.DataAnnotations;

namespace FullStackProject.Models
{
    public class Students
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string StudentName { get; set; }
        [Required]
        public string StudentDepartment { get; set; }
        [Required]
        public string StudentEmail { get; set;}
        [Required]
        public int StudentAge { get; set; }
        [Required]
        public string StudentPhone { get; set;}
        [Required]
        public long StudentFees { get; set; }
    }
}
