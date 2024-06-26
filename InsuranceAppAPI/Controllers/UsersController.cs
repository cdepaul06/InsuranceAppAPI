﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InsuranceAppAPI.Models;

namespace InsuranceAppAPI.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly InsuranceDBContext _context;

        public UsersController(InsuranceDBContext context)
        {
            _context = context;
        }

        #region GET - Users
        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
        #endregion

        #region GET - User by ID
        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        #endregion

        #region PUT - User by ID
        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        #region POST - User
        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }
        #endregion

        #region DELETE - User by ID
        // DELETE: api/Users/5
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(IEnumerable<int> userIds)
        {
            var usersToDelete = await _context.Users.Where(u => userIds.Contains(u.UserId)).ToListAsync();

            if (usersToDelete == null)
            {
                return NotFound();
            }

            _context.Users.RemoveRange(usersToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        #region Utility Functions
        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
        #endregion
    }
}
