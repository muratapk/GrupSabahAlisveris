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
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var sorgu = _context.Admins.Find(id);
            return View(sorgu);
        }
        [HttpPost]
        public IActionResult Edit(Admin gelen)
        {
            _context.Admins.Update(gelen);
            _context.SaveChanges();
            TempData["Success"] = "İşlem Başarılı";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var sorgu = _context.Admins.Find(id);
            return View(sorgu);
        }
        [HttpPost]
        public IActionResult Delete(Admin gelen)
        {
            _context.Admins.Remove(gelen);
            _context.SaveChanges();
            TempData["Success"] = "İşlem Başarılı";
            return RedirectToAction("Index");
        }
    }
}
