using Microsoft.AspNetCore.Mvc;

namespace Week10Assessment.Controllers
{
    public class MarketController : Controller
    {
        
        public IActionResult Summary()
        {
            ViewBag.MarketStatus = "Open";
            ViewData["TopGainer"] = "Apple";
            ViewData["Volume"] = 125550;
            return View();
        }    
        
        public IActionResult Analyze(string ticker, int? days)
        {
            if (days == null)
            {
                days = 30;
            }
            ViewBag.Ticker = ticker;
            ViewBag.Days = days;
            return View();
        }
    }
}
