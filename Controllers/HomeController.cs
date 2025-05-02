using System.Diagnostics;
using Homework_SkillTree.Interfaces.Services;
using Homework_SkillTree.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homework_SkillTree.Controllers
{
    public class HomeController(ILogger<HomeController> logger, IHomeService service) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;

        public async Task<IActionResult> Index(HomeViewModel? viewModel)
        {
            viewModel ??= new HomeViewModel();
            //  暫時綁定每頁10筆
            var pageSize = 10;
            
            viewModel.HomeDataModels = 
                await service.GetAccountBooksAsync(viewModel.CurrentPage, pageSize);
            
            viewModel.TotalPages = (await service.GetAccountBooksCountAsync()) / pageSize;
            
            return View(viewModel);
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
