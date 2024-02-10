using GrupSabahAlisveris.Data;
using Microsoft.AspNetCore.Mvc;
using GrupSabahAlisveris.Models;
namespace GrupSabahAlisveris.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        //public LoginController(ApplicationDbContext context)
        //{
        //    _context=context;
        //}
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EnterLogin(Admin gelen)
        { //Where 
            var sorgu = _context.Admins.Where(x => x.AdminName == gelen.AdminName && x.AdminPassword == gelen.AdminPassword).FirstOrDefault();
            if(sorgu != null) {
                TempData["Success"] = "İşlem Başarılı";
                return RedirectToAction("Index", "Categories");
            }
            TempData["Error"] = "Kullanıcı ve Şifre Hatalı";
            return RedirectToAction("Index","Login");
        }
    }
}
