using FullStackProject.Database;
using FullStackProject.DTO.College;
using FullStackProject.DTO.Student;
using FullStackProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullStackProject.Controllers
{
    [Route("api/college")]
    [ApiController]
    public class CollegeController : ControllerBase
    {
        private readonly DatabaseDbContext dbcontext;
        public CollegeController(DatabaseDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpPost("save")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CreateCollegeDto> createLogin([FromBody] CreateCollegeDto college)
        {
           College college_ = new College();
            college_.CollegeName = college.CollegeName;
            college_.CollegeRank = college.CollegeRank;
            college_.CollegeType = college.CollegeType;
            dbcontext.colleges.Add(college_);
            dbcontext.SaveChanges();
            return Ok(college_);
        }
        [HttpGet("getAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<GetCollegeDto> getAll()
        {
            var get = dbcontext.colleges.ToList();
            return Ok(get);
        }
        [HttpGet("getstudent/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<GetCollegeDto> getAction(int id)
        {
            var getcollege = dbcontext.colleges.Find(id);
            if (id != 0)
            {
                if (getcollege != null)
                {
                    return Ok(getcollege);
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
        public ActionResult<UpdateCollegeDto> updateLogin(int id, [FromBody] UpdateCollegeDto college)
        {
            var college_ = dbcontext.colleges.Find(id);
            if (id != 0)
            {
                if (college != null)
                {
                   college_.CollegeName = college.CollegeName;
                    college_.CollegeRank= college.CollegeRank;
                    college_.CollegeType= college.CollegeType;
                    dbcontext.SaveChanges();
                    return Ok(college_);
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
            var deleteCollege = dbcontext.colleges.Find(id);
            if (id != 0)
            {
                if (deleteCollege != null)
                {
                    dbcontext.Remove(deleteCollege);
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
