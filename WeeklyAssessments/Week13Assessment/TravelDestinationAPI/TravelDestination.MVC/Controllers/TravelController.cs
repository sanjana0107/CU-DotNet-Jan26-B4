using Microsoft.AspNetCore.Mvc;
using TravelDestination.MVC.Models;
using TravelDestination.MVC.Services;

namespace TravelDestination.MVC.Controllers
{
    public class TravelController : Controller
    {
        private readonly IDestinationService _service;

        public TravelController(IDestinationService service)
        {
            _service = service;
        }

        
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Destination dto)
        {
            if (!ModelState.IsValid)
                return View(dto);
            await _service.CreateAsync(dto);
            return RedirectToAction("Index");
        }


    }
}
