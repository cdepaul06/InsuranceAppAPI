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
    [Route("api/UserStatuses")]
    [ApiController]
    public class UserStatusController : ControllerBase
    {
        private readonly InsuranceDBContext _context;

        public UserStatusController(InsuranceDBContext context)
        {
            _context = context;
        }

        #region GET - UserStatuses
        // GET: api/UserStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserStatus>>> GetUserStatuses()
        {
            return await _context.UserStatuses.ToListAsync();
        }

        #endregion

        #region GET - UserStatus by ID
        // GET: api/UserStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserStatus>> GetUserStatus(int id)
        {
            var userStatus = await _context.UserStatuses.FindAsync(id);

            if (userStatus == null)
            {
                return NotFound();
            }

            return userStatus;
        }
        #endregion

        #region PUT - UserStatus by ID
        // PUT: api/UserStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserStatus(int id, UserStatus userStatus)
        {
            if (id != userStatus.UserStatusId)
            {
                return BadRequest();
            }

            _context.Entry(userStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserStatusExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        #endregion

        #region POST - UserStatus
        // POST: api/UserStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserStatus>> PostUserStatus(UserStatus userStatus)
        {
            _context.UserStatuses.Add(userStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserStatus", new { id = userStatus.UserStatusId }, userStatus);
        }
        #endregion

        #region DELETE - UserStatus by ID
        // DELETE: api/UserStatus/5
        [HttpDelete]
        public async Task<IActionResult> DeleteUserStatus(IEnumerable<int> userStatusIds)
        {
            var userStatusesToDelete = await _context.UserStatuses.Where(x => userStatusIds.Contains(x.UserStatusId)).ToListAsync();
            if (userStatusesToDelete == null)
            {
                return NotFound();
            }

            _context.UserStatuses.RemoveRange(userStatusesToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion+

        #region Utility Functions
        private bool UserStatusExists(int id)
        {
            return _context.UserStatuses.Any(e => e.UserStatusId == id);
        }
        #endregion
    }
}
