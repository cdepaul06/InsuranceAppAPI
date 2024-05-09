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
    [Route("api/auth/login")]
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

    }
}
