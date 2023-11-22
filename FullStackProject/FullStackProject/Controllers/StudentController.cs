using FullStackProject.Database;
using FullStackProject.DTO.Student;
using FullStackProject.DTO.Teacher;
using FullStackProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullStackProject.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly DatabaseDbContext dbcontext;
        public StudentController(DatabaseDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpPost("save")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CreateStudentDto> createLogin([FromBody] CreateStudentDto student)
        {
           Students student_ = new Students();
            student_.StudentName = student.StudentName;
            student_.StudentDepartment = student.StudentDepartment;
            student_.StudentEmail=student.StudentEmail;
            student_.StudentPhone = student.StudentPhone;
            student_.StudentAge = student.StudentAge;
            student_.StudentFees= student.StudentFees;
            dbcontext.students.Add(student_);
            dbcontext.SaveChanges();
            return Ok(student_);
        }
        [HttpGet("getAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<GetStudentDto> getAll()
        {
            var get = dbcontext.students.ToList();
            return Ok(get);
        }
        [HttpGet("getstudent/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<GetStudentDto> getAction(int id)
        {
            var getstudent = dbcontext.students.Find(id);
            if (id != 0)
            {
                if (getstudent != null)
                {
                    return Ok(getstudent);
                }
                else
                {
                    return NoContent();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("update/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UpdateStudentDto> updateLogin(int id, [FromBody] UpdateStudentDto student)
        {
            var student_ = dbcontext.students.Find(id);
            if (id != 0)
            {
                if (student != null)
                {
                    student_.StudentName = student.StudentName;
                    student_.StudentEmail = student.StudentEmail;
                    student_.StudentPhone = student.StudentPhone;
                    student_.StudentDepartment = student.StudentDepartment;
                    student_.StudentAge = student.StudentAge;
                    student_.StudentFees = student.StudentFees;
                    dbcontext.SaveChanges();
                    return Ok(student_);
                }
                else
                {
                    return NoContent();
                }
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("delete/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult deleteLogin(int id)
        {
            var deleteStudent = dbcontext.students.Find(id);
            if (id != 0)
            {
                if (deleteStudent != null)
                {
                    dbcontext.Remove(deleteStudent);
                    dbcontext.SaveChanges();
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
