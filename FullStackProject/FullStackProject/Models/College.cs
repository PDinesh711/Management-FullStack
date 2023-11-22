using System.ComponentModel.DataAnnotations;

namespace FullStackProject.Models
{
    public class College
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CollegeName { get; set; }
        [Required]
        public long CollegeRank { get; set; }
        [Required]
        public string CollegeType { get; set; }
    }
}
