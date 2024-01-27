using GrupSabahAlisveris.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GrupSabahAlisveris.Models;

namespace GrupSabahAlisveris.ViewComponents
{
    public class SliderComponentList: ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public SliderComponentList(ApplicationDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var sonuc = _context.Products.ToList();
            return View(sonuc);
        }
    }
}
