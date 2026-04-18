using Microsoft.AspNetCore.Mvc;
using NorthWind.Services.DTOs;

namespace NorthWind.MVC.Controllers
{
    public class SummaryController : Controller
    {
        private readonly HttpClient _client;

        public SummaryController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("API");
        }
        public async Task<IActionResult> Index()
        {
            var summary = await _client.GetFromJsonAsync<List<CategorySummaryDto>>
                ("api/products/summary");

            return View(summary);
        }

    }
}
