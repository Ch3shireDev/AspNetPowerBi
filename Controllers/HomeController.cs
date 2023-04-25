using AspNetPowerBi.Models;
using AspNetPowerBi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspNetPowerBi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PowerBiService _powerBiService;
        public HomeController(ILogger<HomeController> logger, PowerBiService service)
        {
            _logger = logger;
            _powerBiService = service;
        }

        public async Task<IActionResult> Index()
        {
            var config = await _powerBiService.GetEmbedConfig();
            return View(config);
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