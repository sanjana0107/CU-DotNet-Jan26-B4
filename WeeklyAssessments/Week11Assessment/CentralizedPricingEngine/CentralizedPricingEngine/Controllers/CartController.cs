using CentralizedPricingEngine.Services;
using Microsoft.AspNetCore.Mvc;

namespace CentralizedPricingEngine.Controllers
{
    public class CartController : Controller
    {
        private IPricingService _interface { get; set; }

        public CartController(IPricingService service)
        {
            _interface = service;                        
        }

        [HttpPost]
        public IActionResult AddToCart(double basePrice, string promocode)
        {
            return RedirectToAction("Index", new { basePrice, promocode });
        }
            
        public IActionResult Index(double basePrice, string promocode)
        {
            double calculatedPrice = _interface.CalculateDiscount(basePrice, promocode);
            ViewBag.basePrice = basePrice;
            ViewBag.promocode = promocode;
            ViewBag.discountedPrice = calculatedPrice;
            return View();
        }
    }
}
