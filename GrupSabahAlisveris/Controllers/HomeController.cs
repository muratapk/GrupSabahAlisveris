using GrupSabahAlisveris.Data;
using GrupSabahAlisveris.Models;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using System.Diagnostics;

namespace GrupSabahAlisveris.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
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
        public IActionResult ProductDetails(int? id)
        {
            var sorgu = _context.Products.Where(x => x.Product_Id == id).FirstOrDefault();
            return View(sorgu);
        }
        public IActionResult ProductList(int ? id)
        {
            var sorgu = _context.Products.Where(x => x.Category_Id == id).ToList();
            return View(sorgu);
        }
    }
}
