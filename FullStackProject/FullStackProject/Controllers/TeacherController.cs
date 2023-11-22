using FullStackProject.Database;
using FullStackProject.DTO.Login;
using FullStackProject.DTO.Teacher;
using FullStackProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullStackProject.Controllers
{
    [Route("api/teacher")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly DatabaseDbContext dbcontext;
        public TeacherController(DatabaseDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpPost("save")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CreateTeacherDto> createLogin([FromBody] CreateTeacherDto teacher)
        {
            Teachers teachers_ = new Teachers();
            teachers_.TeacherName= teacher.TeacherName;
            teachers_.TeacherSubject= teacher.TeacherSubject;
            teachers_.TeacherSalary= teacher.TeacherSalary;
            dbcontext.teachers.Add(teachers_);
            dbcontext.SaveChanges();
            return Ok();
        }
        [HttpGet("getAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<GetTeacherDto> getAll()
        {
            var get = dbcontext.teachers.ToList();
            return Ok(get);
        }
        [HttpGet("getlogin/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<GetTeacherDto> getAction(int id)
        {
            var getTeacher = dbcontext.teachers.Find(id);
            if (id != 0)
            {
                if (getTeacher != null)
                {
                    return Ok(getTeacher);
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
        public ActionResult<UpdateTeacherDto> updateLogin(int id, [FromBody] UpdateTeacherDto teacher)
        {
            var teacher_ = dbcontext.teachers.Find(id);
            if (id != 0)
            {
                if (teacher != null)
                {
                    teacher_.TeacherName= teacher.TeacherName;
                    teacher_.TeacherSubject= teacher.TeacherSubject;
                    teacher_.TeacherSalary= teacher.TeacherSalary;
                    dbcontext.SaveChanges();
                    return Ok();
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
            var deleteTeacher = dbcontext.teachers.Find(id);
            if (id != 0)
            {
                if (deleteTeacher != null)
                {
                    dbcontext.Remove(deleteTeacher);
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
