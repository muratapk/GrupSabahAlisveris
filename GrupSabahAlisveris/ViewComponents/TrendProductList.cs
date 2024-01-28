using GrupSabahAlisveris.Data;
using Microsoft.AspNetCore.Mvc;

namespace GrupSabahAlisveris.ViewComponents
{
    public class TrendProductList:ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public TrendProductList(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var sorgu = _context.Products.OrderByDescending(x => x.Product_Id).Take(8).ToList();
            return View(sorgu);
        }
    }
}
