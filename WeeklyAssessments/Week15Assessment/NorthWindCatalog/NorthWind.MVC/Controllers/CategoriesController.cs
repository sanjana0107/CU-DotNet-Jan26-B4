using Microsoft.AspNetCore.Mvc;
using NorthWind.Services.DTOs;

namespace NorthWind.MVC.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly HttpClient _client;

        public CategoriesController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("API");
        }

        public async Task<IActionResult> Index()
        {
            var data = await _client.GetFromJsonAsync<List<CategoryDto>>("api/categories");
            return View(data);
        }
    }
}
