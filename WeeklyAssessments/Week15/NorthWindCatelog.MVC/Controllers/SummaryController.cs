using Microsoft.AspNetCore.Mvc;
using NorthWindCatelog.MVC.DTOs;
using System.Net.Http;
using System.Net.Http.Json;

namespace NorthWindCatelog.MVC.Controllers
{
    public class SummaryController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public SummaryController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient("ApiClient");
            var summary = await client.GetFromJsonAsync<List<SummaryDto>>("api/products/summary");
            return View(summary);
        }
    }
}
