using InsuranceAppAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsuranceAppAPI.Controllers
{
    [Route("api/UserTypes")]
    [ApiController]
    public class UserTypesController : ControllerBase
    {
        private readonly InsuranceDBContext _context;

        public UserTypesController(InsuranceDBContext context)
        {
            _context = context;
        }

        #region GET - UserTypes
        // GET: api/UserTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserType>>> GetUserTypes()
        {
            return await _context.UserTypes.ToListAsync();
        }

        #endregion

        #region GET - UserType by ID
        // GET: api/UserTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserType>> GetUserType(int id)
        {
            var userType = await _context.UserTypes.FindAsync(id);

            if (userType == null)
            {
                return NotFound();
            }

            return userType;
        }
        #endregion

        #region PUT - UserType by ID
        // PUT: api/UserTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserType(int id, UserType userType)
        {
            if (id != userType.UserTypeId)
            {
                return BadRequest();
            }

            _context.Entry(userType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTypeExists(id))
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

        #region POST - UserType
        // POST: api/UserTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserType>> PostUserType(UserType userType)
        {
            _context.UserTypes.Add(userType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserType", new { id = userType.UserTypeId }, userType);
        }
        #endregion

        #region DELETE - UserType by ID
        // DELETE: api/UserTypes/5
        [HttpDelete]
        public async Task<IActionResult> DeleteUserType(IEnumerable<int> userTypeIds)
        {
            var userTypesToDelete = await _context.UserTypes.Where(x => userTypeIds.Contains(x.UserTypeId)).ToListAsync();
            if (userTypesToDelete == null)
            {
                return NotFound();
            }

            _context.UserTypes.RemoveRange(userTypesToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        #region Utility Functions
        private bool UserTypeExists(int id)
        {
            return _context.UserTypes.Any(e => e.UserTypeId == id);
        }
        #endregion
    }
}
