using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InsuranceAppAPI.Models;
using System.Net.Http.Headers;
using InsuranceAppAPI.Services;

namespace InsuranceAppAPI.Controllers
{
    [Route("api/CustomerPolicyLines")]
    [ApiController]
    public class CustomerPolicyLinesController : ControllerBase
    {
        private readonly InsuranceDBContext _context;
        private readonly VinLookupService _vinLookupService;

        public CustomerPolicyLinesController(InsuranceDBContext context, VinLookupService vinLookupService)
        {
            _context = context;
            _vinLookupService = vinLookupService;   
        }

        // GET: api/CustomerPolicyLines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerPolicyLine>>> GetCustomerPolicyLines()
        {
            return await _context.CustomerPolicyLines.ToListAsync();
        }

        // GET: api/CustomerPolicyLines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerPolicyLine>> GetCustomerPolicyLine(int id)
        {
            var customerPolicyLine = await _context.CustomerPolicyLines.FindAsync(id);

            if (customerPolicyLine == null)
            {
                return NotFound();
            }

            return customerPolicyLine;
        }

        [HttpGet("vin/{vin}/{year}")]
        public async Task<ActionResult<string>> GetVin(string vin, int year)
        {
            return await _vinLookupService.VinLookup(vin, year);
        }

        // PUT: api/CustomerPolicyLines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerPolicyLine(int id, CustomerPolicyLine customerPolicyLine)
        {
            if (id != customerPolicyLine.CustomerPolicyLineId)
            {
                return BadRequest();
            }

            _context.Entry(customerPolicyLine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerPolicyLineExists(id))
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

        // POST: api/CustomerPolicyLines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerPolicyLine>> PostCustomerPolicyLine(CustomerPolicyLine customerPolicyLine)
        {
            _context.CustomerPolicyLines.Add(customerPolicyLine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerPolicyLine", new { id = customerPolicyLine.CustomerPolicyLineId }, customerPolicyLine);
        }

        // DELETE: api/CustomerPolicyLines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerPolicyLine(int id)
        {
            var customerPolicyLine = await _context.CustomerPolicyLines.FindAsync(id);
            if (customerPolicyLine == null)
            {
                return NotFound();
            }

            _context.CustomerPolicyLines.Remove(customerPolicyLine);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerPolicyLineExists(int id)
        {
            return _context.CustomerPolicyLines.Any(e => e.CustomerPolicyLineId == id);
        }
    }
}
