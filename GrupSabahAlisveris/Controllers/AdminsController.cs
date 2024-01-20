using GrupSabahAlisveris.Data;
using GrupSabahAlisveris.Models;
using Microsoft.AspNetCore.Mvc;

namespace GrupSabahAlisveris.Controllers
{
    public class AdminsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public AdminsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            var sorgu = _context.Admins.ToList();
            return View(sorgu);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Admin gelen)
        {
            _context.Admins.Add(gelen);
            _context.SaveChanges();
            TempData["Success"] = "İşlem Başarılı";
            return RedirectToAction("Index");
        }
    }
}
