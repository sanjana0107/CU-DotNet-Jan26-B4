using Microsoft.AspNetCore.Mvc;
using NorthWindCatelog.MVC.DTOs;

namespace NorthWindCatelog.MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly HttpClient _client;

        public ProductsController(HttpClient client)
        {
            _client = client;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ByCategory(int id)
        {
            var products = await _client.GetFromJsonAsync<List<ProductDto>>
                ($"api/products/by-category/{id}");

            return View(products);
        }



    }
}
