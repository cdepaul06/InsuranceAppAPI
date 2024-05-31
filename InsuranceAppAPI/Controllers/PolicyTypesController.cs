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
    [Route("api/PolicyTypes")]
    [ApiController]
    public class PolicyTypesController : ControllerBase
    {
        private readonly InsuranceDBContext _context;

        public PolicyTypesController(InsuranceDBContext context)
        {
            _context = context;
        }

        #region GET - PolicyTypes
        // GET: api/PolicyTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PolicyType>>> GetPolicyTypes()
        {
            return await _context.PolicyTypes.ToListAsync();
        }
        #endregion

        #region GET - PolicyType by ID
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
        #endregion

        #region PUT - PolicyType by ID
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
        #endregion

        #region POST - PolicyType
        // POST: api/PolicyTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PolicyType>> PostPolicyType(PolicyType policyType)
        {
            _context.PolicyTypes.Add(policyType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPolicyType", new { id = policyType.PolicyTypeId }, policyType);
        }
        #endregion

        #region DELETE - PolicyType by ID
        // DELETE: api/PolicyTypes/5
        [HttpDelete]
        public async Task<IActionResult> DeletePolicyType(IEnumerable<int> policyTypeIds)
        {
            var policyTypesToDelete = await _context.PolicyTypes.Where(x => policyTypeIds.Contains(x.PolicyTypeId)).ToListAsync();
            if (policyTypesToDelete == null)
            {
                return NotFound();
            }

            _context.PolicyTypes.RemoveRange(policyTypesToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        #region Utility Functions
        private bool PolicyTypeExists(int id)
        {
            return _context.PolicyTypes.Any(e => e.PolicyTypeId == id);
        }
        #endregion
    }
}
