using GrupSabahAlisveris.Data;
using Microsoft.AspNetCore.Mvc;

namespace GrupSabahAlisveris.ViewComponents
{
    public class KategoriMenuList:ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public KategoriMenuList(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var sorgu = _context.Categories.ToList();
            return View(sorgu);
        }
    }
}
