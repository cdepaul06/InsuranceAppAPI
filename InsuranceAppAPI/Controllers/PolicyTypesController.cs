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
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyTypesController : ControllerBase
    {
        private readonly InsuranceDBContext _context;

        public PolicyTypesController(InsuranceDBContext context)
        {
            _context = context;
        }

        // GET: api/PolicyTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PolicyType>>> GetPolicyTypes()
        {
            return await _context.PolicyTypes.ToListAsync();
        }

        // GET: api/PolicyTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PolicyType>> GetPolicyType(int id)
        {
            var policyType = await _context.PolicyTypes.FindAsync(id);

            if (policyType == null)
            {
                return NotFound();
            }

            return policyType;
        }

        // PUT: api/PolicyTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPolicyType(int id, PolicyType policyType)
        {
            if (id != policyType.PolicyTypeId)
            {
                return BadRequest();
            }

            _context.Entry(policyType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolicyTypeExists(id))
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

        // POST: api/PolicyTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PolicyType>> PostPolicyType(PolicyType policyType)
        {
            _context.PolicyTypes.Add(policyType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPolicyType", new { id = policyType.PolicyTypeId }, policyType);
        }

        // DELETE: api/PolicyTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolicyType(int id)
        {
            var policyType = await _context.PolicyTypes.FindAsync(id);
            if (policyType == null)
            {
                return NotFound();
            }

            _context.PolicyTypes.Remove(policyType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PolicyTypeExists(int id)
        {
            return _context.PolicyTypes.Any(e => e.PolicyTypeId == id);
        }
    }
}
