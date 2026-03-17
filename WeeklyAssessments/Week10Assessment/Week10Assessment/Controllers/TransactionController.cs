using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Week10Assessment.Data;
using Week10Assessment.Models;

namespace Week10Assessment.Controllers
{
    public class TransactionController : Controller
    {
        private readonly Week10AssessmentContext _context;

        public TransactionController(Week10AssessmentContext context)
        {
            _context = context;
        }

        // GET: Transaction
        public async Task<IActionResult> Index()
        {
            var week10AssessmentContext = _context.Transaction.Include(t => t.Account);
            return View(await week10AssessmentContext.ToListAsync());
        }

        // GET: Transaction/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction
                .Include(t => t.Account)
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // GET: Transaction/Create
        // This action both shows the create form and accepts query-submissions (keeps your view unchanged).
        public IActionResult Create(int? accountId)
        {
            var model = new Transaction();
            if (accountId.HasValue)
            {
                model.AccountId = accountId.Value;
                model.Account = _context.Account.AsNoTracking().FirstOrDefault(a => a.AccountId == accountId.Value);
            }

            // build dropdown "AccountNumber - Name"
            var accounts = _context.Account
                .AsNoTracking()
                .Select(a => new { a.AccountId, Display = a.AccountNumber.ToString() + " - " + a.Name })
                .ToList();
            ViewBag.AccountId = new SelectList(accounts, "AccountId", "Display", model.AccountId);

            return View(model);
        }

        // POST: Transaction/Create
        // Keep this as well so standard POSTs (if any) are handled.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransactionId,Description,Amount,Category,Date,AccountId")] Transaction transaction)
        {
            var accounts = _context.Account
                .AsNoTracking()
                .Select(a => new { a.AccountId, Display = a.AccountNumber.ToString() + " - " + a.Name })
                .ToList();
            ViewBag.AccountId = new SelectList(accounts, "AccountId", "Display", transaction.AccountId);

            if (transaction.AccountId == 0 || !_context.Account.Any(a => a.AccountId == transaction.AccountId))
            {
                ModelState.AddModelError(nameof(transaction.AccountId), "Please select a valid account.");
            }

            if (string.IsNullOrWhiteSpace(transaction.Category))
            {
                ModelState.AddModelError(nameof(transaction.Category), "Category is required.");
            }

            if (transaction.Date == default) transaction.Date = DateTime.UtcNow;

            if (!ModelState.IsValid)
            {
                if (transaction.AccountId != 0)
                    transaction.Account = _context.Account.AsNoTracking().FirstOrDefault(a => a.AccountId == transaction.AccountId);

                return View(transaction);
            }

            _context.Transaction.Add(transaction);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Account");
        }

        // GET: Transaction/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            ViewData["AccountId"] = new SelectList(_context.Account, "AccountId", "AccountId", transaction.AccountId);
            return View(transaction);
        }

        // POST: Transaction/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransactionId,Description,Amount,Category,Date,AccountId")] Transaction transaction)
        {
            if (id != transaction.TransactionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transaction.TransactionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction("Index", "Account");
            }
            ViewData["AccountId"] = new SelectList(_context.Account, "AccountId", "AccountId", transaction.AccountId);
            return View(transaction);
        }

        // GET: Transaction/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction
                .Include(t => t.Account)
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaction = await _context.Transaction.FindAsync(id);
            if (transaction != null)
            {
                _context.Transaction.Remove(transaction);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Account");
        }

        private bool TransactionExists(int id)
        {
            return _context.Transaction.Any(e => e.TransactionId == id);
        }
    }
}
