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
            CartViewModel cartVm = new() {
                CartItems = cart,
                GrandTotal = cart.Sum(x => x.Quantity * x.Price),
            
            };

            return View(cartVm);

        }
        public async Task<IActionResult>CartList()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            return View(cart);
        }

        public async Task<IActionResult>Add(int id)
        {
            Product product = await _context.Products.FindAsync(id);
            //gelen ürününü buldum
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartItem cartItem=cart.FirstOrDefault(c=>c.ProductId == id);
            if(cartItem==null)
            {
                cart.Add(new CartItem(product));
            }
            else
            {
                cartItem.Quantity += 1;

            }
            HttpContext.Session.SetJson("Cart", cart);
            TempData["Success"] = "Sepete Eklendi";
            return Redirect(Request.Headers["Referer"].ToString());
            
        }
        //Sepetten tek bir ürün azaltma
        public async Task<IActionResult> Decrease(int id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
            //session içindeki listeyi al  bunu cart
            CartItem cartItem = cart.Where(c => c.ProductId == id).FirstOrDefault();
            //session listesi içinde veri varsa  cartItem ata
            if(cartItem.Quantity>1)
            {
                //cartItem içindeki ürün var ve sayısı bir den büyük ise bir azalt
                cartItem.Quantity -= 1;
            }
            else
            {
                //içinde bir ürün varsa sepetteki tüm özellikeri yok adı resmi ve adet bilgileri
                //sil
                cart.RemoveAll(c => c.ProductId == id);
            }
            if(cart.Count>0)
            {
                HttpContext.Session.Remove("cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }
            TempData["Success"] = "Sepetten Silindi";

            return RedirectToAction("Index");
        }

    // Sepeti ürünü sepetten silme
       public async Task<IActionResult> Remove(int id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
            //sepetteki ürünleri getir
            cart.RemoveAll(c => c.ProductId == id);
            if(cart.Count>0)
            {
                HttpContext.Session.Remove("Cart");
                //session içindek anahtarı sil
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
                //session nesnesin için boşlatıktan tekrardan session kayıt yapıyorum Cart anahtarı
                //ile
            }
            TempData["Success"] = "Sepetten Komple Silindi";

            return RedirectToAction("Index");
        }

        //Sepeti Sil
        public async Task<IActionResult>Clear()
        {
            HttpContext.Session.Remove("Cart");

            return RedirectToAction("Index");
        }
    }
}
