using Day55Exercise.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace Day55Exercise.Controllers
{
    public class HomeController : Controller
    {
        List<Employee> empList = new List<Employee>()
        {
            new Employee(1, "Aman", "Manager", 500000),
            new Employee(2, "Shyam", "CEO", 1000000),
            new Employee(3, "Priya", "Accountant", 650000)
        };
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DashBoard()
        {
            string announcement = "This is me...this is all we need...";
            ViewBag.announcement = announcement;

            string deptName = "Finance";
            ViewData["deptName"] = deptName;

            string serverStatus = "Not Available";
            ViewData["serverStatus"] = serverStatus;

            bool isActive = true;
            ViewData["isActive"] = isActive;
            return View(empList);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
