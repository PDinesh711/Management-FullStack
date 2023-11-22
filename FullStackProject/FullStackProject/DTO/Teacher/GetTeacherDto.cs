using System.ComponentModel.DataAnnotations;

namespace FullStackProject.DTO.Teacher
{
    public class GetTeacherDto
    {
        public int Id { get; set; }
        public string TeacherName { get; set; }
        public string TeacherSubject { get; set; }
        public long TeacherSalary { get; set; }
    }
}
