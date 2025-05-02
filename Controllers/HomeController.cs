using System.Diagnostics;
using Homework_SkillTree.Interfaces.Services;
using Homework_SkillTree.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homework_SkillTree.Controllers
{
    public class HomeController(ILogger<HomeController> logger, IHomeService service) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;

        [HttpGet]
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10)
        {
            
            return View(new HomeViewModel
            {
                HomeDataModels = await service.GetAccountBooksAsync(pageNumber, pageSize)
            });
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
