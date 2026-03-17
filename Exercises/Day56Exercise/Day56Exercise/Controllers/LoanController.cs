using System.Collections.Generic;
using System.Linq;
using Day56Exercise.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day56Exercise.Controllers 
{
    public class LoanController : Controller
    {
        private static List<Loan> _loanDetails = new List<Loan>()
        {
            new()
            {
                LoanId = 1,
                LenderName = "Aditi",
                BorrowerName = "Palak",
                Amount = 5000,
                IsSettled = true
            }           
        };

        // GET: LoanController
        public ActionResult Index()
        {
            return View(_loanDetails);
        }

        // GET: LoanController/Details/5
        public ActionResult Details(int id)
        {
            var DetailOfLoanId = _loanDetails.FirstOrDefault(x => x.LoanId == id);
            if (DetailOfLoanId == null) return NotFound();
            return View(DetailOfLoanId);
        }

        // GET: LoanController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoanController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Loan loan)
        {
            if (!ModelState.IsValid)
                return View(loan);

            try
            {
                // assign a new unique Id
                loan.LoanId = _loanDetails.Any() ? _loanDetails.Max(l => l.LoanId) + 1 : 1;
                _loanDetails.Add(loan);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(loan);
            }  
        }

        // GET: LoanController/Edit/5
        public ActionResult Edit(int id)
        {
            var x = _loanDetails.FirstOrDefault(x => x.LoanId == id);
            if (x == null) return NotFound();
            return View(x);
        }

        // POST: LoanController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Loan loan)
        {
            if (!ModelState.IsValid)
                return View(loan);

            try
            {
                var editedDetails = _loanDetails.FirstOrDefault(x => x.LoanId == id);
                if (editedDetails == null) return NotFound();

                editedDetails.BorrowerName = loan.BorrowerName;
                editedDetails.LenderName = loan.LenderName;
                editedDetails.Amount = loan.Amount;
                editedDetails.IsSettled = loan.IsSettled;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(loan);
            }            
        }

        // GET: LoanController/Delete/5
        public ActionResult Delete(int id)
        {
            var idDelete = _loanDetails.FirstOrDefault(x => x.LoanId == id);
            if (idDelete == null) return NotFound();
            return View(idDelete);
        }

        // POST: LoanController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var idDelete = _loanDetails.FirstOrDefault(x => x.LoanId == id);
            if (idDelete != null)
            {
                _loanDetails.Remove(idDelete);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
