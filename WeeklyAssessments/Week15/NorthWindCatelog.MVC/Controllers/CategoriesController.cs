using Microsoft.AspNetCore.Mvc;
using NorthWindCatelog.MVC.DTOs;
using System.Net.Http;
using System.Net.Http.Json;

namespace NorthWindCatelog.MVC.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public CategoriesController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient("ApiClient");
            var data = await client.GetFromJsonAsync<List<CategoryDto>>("api/categories");
            return View(data);
        }
    }
}
