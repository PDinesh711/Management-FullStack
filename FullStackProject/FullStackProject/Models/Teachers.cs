using System.ComponentModel.DataAnnotations;

namespace FullStackProject.Models
{
    public class Teachers
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TeacherName { get; set; }
        [Required]
        public string TeacherSubject { get; set; }
        [Required]
        public long TeacherSalary { get; set; }
    }
}
