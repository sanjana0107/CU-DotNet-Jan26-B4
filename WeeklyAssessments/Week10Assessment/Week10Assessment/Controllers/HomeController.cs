using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Week10Assessment.Models;
using System.Text.Json;

namespace Week10Assessment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // read assets exposed by PortfolioController
            var assets = PortfolioController.Assets;

            // total asset value
            decimal totalValue = assets?.Sum(a => (decimal)a.Quantity * a.Price) ?? 0m;
            ViewData["TotalAssetValue"] = totalValue.ToString("C");

            // prepare JSON arrays for chart labels and data
            var labels = assets?.Select(a => a.AssetName).ToArray() ?? Array.Empty<string>();
            var totals = assets?.Select(a => (decimal)a.Quantity * a.Price).ToArray() ?? Array.Empty<decimal>();

            ViewData["AssetLabelsJson"] = JsonSerializer.Serialize(labels);
            ViewData["AssetTotalsJson"] = JsonSerializer.Serialize(totals);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
