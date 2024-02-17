using GrupSabahAlisveris.Data;
using GrupSabahAlisveris.Dto;
using GrupSabahAlisveris.Models;
using GrupSabahAlisveris.Oturum;
using Microsoft.AspNetCore.Mvc;

namespace GrupSabahAlisveris.ViewComponents
{
    public class CartSumList:ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public CartSumList(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            CartViewModel cartVm = new CartViewModel()
                 {

                CartItems = cart,
                GrandTotal = cart.Sum(x => x.Quantity * x.Price),


                  };
            return View(cartVm);
                
        }
    }
}
