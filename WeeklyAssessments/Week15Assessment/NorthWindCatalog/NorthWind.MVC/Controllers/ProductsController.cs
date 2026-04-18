using Microsoft.AspNetCore.Mvc;
using NorthWind.Services.DTOs;

namespace NorthWind.MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly HttpClient _client;

        public ProductsController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("API");
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
