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
    [Route("api/CustomerPolicies")]
    [ApiController]
    public class CustomerPoliciesController : ControllerBase
    {
        private readonly InsuranceDBContext _context;

        public CustomerPoliciesController(InsuranceDBContext context)
        {
            _context = context;
        }

        #region GET - CustomerPolicies
        // GET: api/CustomerPolicies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerPolicy>>> GetCustomerPolicies()
        {
            return await _context.CustomerPolicies.ToListAsync();
        }
        #endregion

        #region GET - CustomerPolicy by ID
        // GET: api/CustomerPolicies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerPolicy>> GetCustomerPolicy(int id)
        {
            var customerPolicy = await _context.CustomerPolicies.FindAsync(id);

            if (customerPolicy == null)
            {
                return NotFound();
            }

            return customerPolicy;
        }
        #endregion

        #region PUT - CustomerPolicy by ID
        // PUT: api/CustomerPolicies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerPolicy(int id, CustomerPolicy customerPolicy)
        {
            if (id != customerPolicy.CustomerPolicyId)
            {
                return BadRequest();
            }

            _context.Entry(customerPolicy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerPolicyExists(id))
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

        #region POST - CustomerPolicy
        // POST: api/CustomerPolicies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerPolicy>> PostCustomerPolicy(CustomerPolicy customerPolicy)
        {
            _context.CustomerPolicies.Add(customerPolicy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerPolicy", new { id = customerPolicy.CustomerPolicyId }, customerPolicy);
        }
        #endregion

        #region DELETE - CustomerPolicy by ID
        // DELETE: api/CustomerPolicies/5
        [HttpDelete]
        public async Task<IActionResult> DeleteCustomerPolicy(IEnumerable<int> customerPolicyIds)
        {
            var customerPoliciesToDelete = await _context.CustomerPolicies.Where(x => customerPolicyIds.Contains(x.CustomerPolicyId)).ToListAsync();
            if (customerPoliciesToDelete == null)
            {
                return NotFound();
            }

            _context.CustomerPolicies.RemoveRange(customerPoliciesToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        #region Utility Functions
        private bool CustomerPolicyExists(int id)
        {
            return _context.CustomerPolicies.Any(e => e.CustomerPolicyId == id);
        }
        #endregion
    }
}
