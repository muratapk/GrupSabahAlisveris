using GrupSabahAlisveris.Data;
using Microsoft.AspNetCore.Mvc;
using GrupSabahAlisveris.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
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
        public async Task<IActionResult> EnterLogin(Admin gelen)
        { //Where 
            var sorgu = _context.Admins.Where(x => x.AdminName == gelen.AdminName && x.AdminPassword == gelen.AdminPassword).FirstOrDefault();
            if (sorgu != null) {
                TempData["Success"] = "İşlem Başarılı";
                HttpContext.Session.SetString("UserSession", gelen.AdminName);
                var claims = new List<Claim> {
                     new Claim(ClaimTypes.Name, gelen.AdminName),
                     new Claim(ClaimTypes.SerialNumber, gelen.AdminPassword),
                     new Claim(ClaimTypes.Role,"Admin")
                    };
                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal= new ClaimsPrincipal(claimIdentity);
                var authProperties = new AuthenticationProperties();
                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Products");
            }
            TempData["Error"] = "Kullanıcı ve Şifre Hatalı";
            return RedirectToAction("Index","Login");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Admin gelen)
        {
            if(gelen!=null)
            {

                var sorgu = _context.Admins.Where(x => x.AdminEmail == gelen.AdminEmail).FirstOrDefault();
                if(sorgu!=null)
                {
                    TempData["Error"] = "Bu Kullanıcı Adında Email Bulunmaktadır";
                    return View();
                }
                else
                {
                    _context.Admins.Add(gelen);
                    _context.SaveChanges();
                    TempData["Success"] = "İşlem Başarılı";
                    return RedirectToAction("Index", "Admins");


                }
               
            }
            TempData["Error"] = "Hata Oluştu";
            return View();
        }

    }
}
