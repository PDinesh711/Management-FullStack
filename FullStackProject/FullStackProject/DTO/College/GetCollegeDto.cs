using System.ComponentModel.DataAnnotations;

namespace FullStackProject.DTO.College
{
    public class GetCollegeDto
    {
        public int Id { get; set; }
        public string CollegeName { get; set; }
        public long CollegeRank { get; set; }
        public string CollegeType { get; set; }
    }
}
