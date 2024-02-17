using GrupSabahAlisveris.Data;
using GrupSabahAlisveris.Dto;
using GrupSabahAlisveris.Models;
using GrupSabahAlisveris.Oturum;
using Microsoft.AspNetCore.Mvc;

namespace GrupSabahAlisveris.Controllers
{
    public class CartController : Controller
    {

        private readonly ApplicationDbContext _context;
        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

            public IActionResult Index()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            CartViewModel cartVm = new CartViewModel() {
                CartItems = cart,
                GrandTotal = cart.Sum(x => x.Quantity * x.Price),
            
            };

            return View(cartVm);

        }

        public async Task<IActionResult>Add(int id)
        {
            Product product = await _context.Products.FindAsync(id);

            return View();
        }
    }
}
