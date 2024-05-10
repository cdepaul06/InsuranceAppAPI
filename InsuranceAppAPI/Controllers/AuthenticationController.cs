using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InsuranceAppAPI.Models;


namespace InsuranceAppAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        #region Initialize
        private readonly InsuranceDBContext _context;
        public AuthenticationController(InsuranceDBContext context)
        {
            _context = context;
        }
        #endregion

        #region Authenticate User
        [HttpPost]
        [Route("login")]
        public ActionResult<IEnumerable<User>> AuthenticateUser([FromBody] User user)
        {
            var users = _context.Users.ToList();

            var returnUser = users.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefault();

            if (returnUser == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(returnUser);
            }
        }
        #endregion

        #region Authenticate - Create User
        [HttpPost]
        [Route("register")]
        public ActionResult<User> AuthenticateCreateUser([FromBody] User user)
        {
            var users = _context.Users.ToList();
            var returnUser = users.Where(u => u.Email == user.Email).FirstOrDefault();
            if (returnUser == null)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }
        #endregion
    }
}
