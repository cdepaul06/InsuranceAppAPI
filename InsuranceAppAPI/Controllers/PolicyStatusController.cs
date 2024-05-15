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
    [Route("api/PolicyStatuses")]
    [ApiController]
    public class PolicyStatusController : ControllerBase
    {

        #region Initialize
        private readonly InsuranceDBContext _context;

        public PolicyStatusController(InsuranceDBContext context)
        {
            _context = context;
        }
        #endregion

        #region GET - PolicyStatuses
        // GET: api/PolicyStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PolicyStatus>>> GetPolicyStatuses()
        {
            return await _context.PolicyStatuses.ToListAsync();
        }
        #endregion

        #region GET - PolicyStatus by ID
        // GET: api/PolicyStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PolicyStatus>> GetPolicyStatus(int id)
        {
            var policyStatus = await _context.PolicyStatuses.FindAsync(id);

            if (policyStatus == null)
            {
                return NotFound();
            }

            return policyStatus;
        }
        #endregion

        #region PUT - PolicyStatus by ID
        // PUT: api/PolicyStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPolicyStatus(int id, PolicyStatus policyStatus)
        {
            if (id != policyStatus.PolicyStatusId)
            {
                return BadRequest();
            }

            _context.Entry(policyStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolicyStatusExists(id))
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

        #region POST - PolicyStatus
        // POST: api/PolicyStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PolicyStatus>> PostPolicyStatus(PolicyStatus policyStatus)
        {
            _context.PolicyStatuses.Add(policyStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPolicyStatus", new { id = policyStatus.PolicyStatusId }, policyStatus);
        }
        #endregion

        #region DELETE - PolicyStatus by ID
        // DELETE: api/PolicyStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolicyStatus(int id)
        {
            var policyStatus = await _context.PolicyStatuses.FindAsync(id);
            if (policyStatus == null)
            {
                return NotFound();
            }

            _context.PolicyStatuses.Remove(policyStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        #region Utilities
        private bool PolicyStatusExists(int id)
        {
            return _context.PolicyStatuses.Any(e => e.PolicyStatusId == id);
        }
        #endregion
    }
}
