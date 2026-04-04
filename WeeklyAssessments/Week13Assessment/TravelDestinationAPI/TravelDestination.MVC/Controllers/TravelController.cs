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

        //public IActionResult Create()
        //{
        //    return View();
        //}

        //public async Task<IActionResult> Create(Destination dto)
        //{
        //    await _service.CreateAsync(dto);
        //    return RedirectToAction("Index");
        //}

        //public async Task<IActionResult> Edit(int id)
        //{
        //    var data = await _service.GetByIdAsync(id);
        //    return View(data);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(int id, Destination dto)
        //{
        //    await _service.UpdateAsync(id, dto);
        //    return RedirectToAction("Index");
        //}

        //public async Task<IActionResult> Delete(int id)
        //{
        //    await _service.DeleteAsync(id);
        //    return RedirectToAction("Index");
        //}
    }
}
