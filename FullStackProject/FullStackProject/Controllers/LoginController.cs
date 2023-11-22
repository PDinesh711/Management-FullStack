using FullStackProject.Database;
using FullStackProject.DTO.Login;
using FullStackProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FullStackProject.Controllers
{
    [ApiController]
    [Route("api/Login")]
    public class LoginController : ControllerBase
    {
        private readonly DatabaseDbContext _dbcontext;

        public LoginController(DatabaseDbContext _dbcontext)
        {
            this._dbcontext = _dbcontext;  
        }

        [HttpPost("save")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CreateLoginDto> createLogin([FromBody] CreateLoginDto login)
        {
            Login login_ = new Login();
            login_.UserName = login.UserName;
            login_.UserEmail = login.UserEmail;
            login_.UserPhoneNumber = login.UserPhoneNumber;
            login_.UserPassword = login.UserPassword;
            _dbcontext.logins.Add(login_);
            _dbcontext.SaveChanges();
            return Ok(login);
        }
        [HttpGet("getAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<GetLoginDto> getAll()
        {
            var get = _dbcontext.logins.ToList();
            return Ok(get);
        }
        [HttpGet("getlogin/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<GetLoginDto> getAction(int id) 
        {
            var getLogin = _dbcontext.logins.Find(id);
            if(id!=0)
            {
                if(getLogin != null)
                {
                    return Ok(getLogin);
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
        public ActionResult<UpdateLoginDto> updateLogin(int id , [FromBody] UpdateLoginDto login)
        {
            var login_ = _dbcontext.logins.Find(id);
            if (id != 0)
            {
                if(login != null)
                {
                    login_.UserName= login.UserName;
                    login_.UserEmail= login.UserEmail;
                    login_.UserPhoneNumber= login.UserPhoneNumber;
                    login_.UserPassword= login.UserPassword;
                    _dbcontext.SaveChanges();
                    return Ok(login_);
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
            var deletelogin = _dbcontext.logins.Find(id);
            if(id!= 0)
            {
                if(deletelogin != null)
                {
                    _dbcontext.Remove(deletelogin);
                    _dbcontext.SaveChanges();
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
