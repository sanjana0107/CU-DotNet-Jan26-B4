using CentralizedPricingEngine.Services;
using Microsoft.AspNetCore.Mvc;

namespace CentralizedPricingEngine.Controllers
{
    public class ProductController : Controller
    {
        private IPricingService _service { get; set; }

        public ProductController(IPricingService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
