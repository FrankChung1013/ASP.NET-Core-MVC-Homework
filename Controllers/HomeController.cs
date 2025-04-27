using System.Diagnostics;
using Homework_SkillTree.DBModels;
using Homework_SkillTree.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Homework_SkillTree.Controllers
{
    public class HomeController(ILogger<HomeController> logger, MvctutorialContext context) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly MvctutorialContext _context = context;

        [HttpGet]
        public IActionResult Index()
        {
            
            return View(new HomeViewModel
            {
                HomeDataModels = _context.Accountings.ToList()
            });
        }

        [HttpPost]  
        public IActionResult Index(HomeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.HomeDataModels = _context.Accountings.ToList();
                return View(model);
            }

            _context.Accountings.Add(model.Input.Adapt<Accounting>());
            _context.SaveChanges();
            
            return RedirectToAction("Index");
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
