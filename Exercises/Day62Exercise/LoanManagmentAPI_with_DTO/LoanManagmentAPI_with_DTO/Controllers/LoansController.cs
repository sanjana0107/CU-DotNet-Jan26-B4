using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoanManagmentAPI_with_DTO.Data;
using LoanManagmentAPI_with_DTO.Models;
using LoanManagmentAPI_with_DTO.DTOs.Get;
using LoanManagmentAPI_with_DTO.DTOs.Create;
using LoanManagmentAPI_with_DTO.DTOs.Update;
using AutoMapper;

namespace LoanManagmentAPI_with_DTO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly LoanManagmentAPI_with_DTOContext _context;
        private readonly IMapper _mapper;

        public LoansController(LoanManagmentAPI_with_DTOContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
         
        }

        // GET: api/Loans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadDto>>> GetLoan()
        {
            return await _context.Loan
                .Select(x => _mapper.Map<ReadDto>(x))
                .ToListAsync();
        }

        // GET: api/Loans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadDto>> GetLoan(int id)
        {
            var loan = await _context.Loan.FindAsync(id);

            if (loan == null)
            {
                return NotFound();
            }

            return _mapper.Map<ReadDto>(loan);
        }

        // PUT: api/Loans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoan(int id, UpdateDto loan)
        {
            if (id != loan.LoanId)
            {
                return BadRequest();
            }

            var existingLoan = await _context.Loan.FindAsync(id);

            if (existingLoan == null)
                return NotFound();

            _mapper.Map(loan, existingLoan);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(_mapper.Map<ReadDto>(existingLoan));
        }

        // POST: api/Loans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Loan>> PostLoan(CreateDTO createLoan)
        {
            var loan = _mapper.Map<Loan>(createLoan);
            _context.Loan.Add(loan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoan", new { id = loan.LoanId }, loan);
        }

        // DELETE: api/Loans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoan(int id)
        {
            var loan = await _context.Loan.FindAsync(id);
            if (loan == null)
            {
                return NotFound();
            }

            _context.Loan.Remove(loan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoanExists(int id)
        {
            return _context.Loan.Any(e => e.LoanId == id);
        }
    }
}
