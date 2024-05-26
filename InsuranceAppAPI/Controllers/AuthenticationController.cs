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
            else if (returnUser.UserStatusId != 2)
            {
                return Unauthorized();
            }
            else
            {
                returnUser.LastLogin = DateTime.Now;
                _context.Entry(returnUser).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(returnUser);
            }
        }
        #endregion
    }
}
