using Day56Exercise.Models;
using Microsoft.AspNetCore.Http;
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
            try
            {
                _loanDetails.Add(loan);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            
        }

        // GET: LoanController/Edit/5
        public ActionResult Edit(int id)
        {
            var x = _loanDetails.FirstOrDefault(x => x.LoanId == id);
            return View(x);
        }

        // POST: LoanController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Loan loan)
        {
            try
            {
                var editedDetails = _loanDetails.FirstOrDefault(x => x.LoanId == id);
                if(editedDetails != null)
                {
                    editedDetails.BorrowerName = loan.BorrowerName;
                    editedDetails.LenderName =loan.LenderName;
                    editedDetails.Amount = loan.Amount;
                    editedDetails.IsSettled = loan.IsSettled;
                }               
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }            
        }

        // GET: LoanController/Delete/5
        public ActionResult Delete(int id)
        {
            var idDelete = _loanDetails.FirstOrDefault(x => x.LoanId == id);
            return View(idDelete);
        }

        // POST: LoanController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Loan loan)
        {
            var idDelete = _loanDetails.FirstOrDefault(x => x.LoanId == id);
            if(idDelete != null)
            {
                _loanDetails.Remove(idDelete);
            }
            return RedirectToAction("Index");
        }
    }
}
