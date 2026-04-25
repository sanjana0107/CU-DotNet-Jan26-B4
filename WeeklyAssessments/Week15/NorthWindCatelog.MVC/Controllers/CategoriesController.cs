using Microsoft.AspNetCore.Mvc;
using NorthWindCatelog.MVC.DTOs;
using System.Net.Http;
using System.Net.Http.Json;

namespace NorthWindCatelog.MVC.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly HttpClient _client;

        public CategoriesController(IHttpClientFactory client)
        {
            _client = client.CreateClient("API");
            Console.WriteLine(_client.BaseAddress);

        }

        public async Task<IActionResult> Index()
        {           
            var data = await _client.GetFromJsonAsync<List<CategoryDto>>("api/categories");
            return View(data);
        }
    }
}
