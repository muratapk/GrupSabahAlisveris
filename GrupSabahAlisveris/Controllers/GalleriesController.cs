using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GrupSabahAlisveris.Data;
using GrupSabahAlisveris.Models;
using Microsoft.AspNetCore.Http;

namespace GrupSabahAlisveris.Controllers
{
    public class GalleriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GalleriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Galleries
        public async Task<IActionResult> Index(int id)
        {
            var applicationDbContext = _context.Galleries.Where(x=>x.ProductId==id).Include(g => g.Product);
            //select * from product where productId=Id
            ViewBag.ProductId = id;
            //ViewData['Productid'] TempData['ProductId']
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Galleries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Galleries == null)
            {
                return NotFound();
            }

            var gallery = await _context.Galleries
                .Include(g => g.Product)
                .FirstOrDefaultAsync(m => m.GalleryId == id);
            if (gallery == null)
            {
                return NotFound();
            }

            return View(gallery);
        }

        // GET: Galleries/Create
        public IActionResult Create(int id)
        {
            //ViewData["ProductId"] = new SelectList(_context.Products, "Product_Id", "Product_Name");
            ViewBag.ProductId = id;
            return View();
        }

        // POST: Galleries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GalleryId,ProductId,Image")] Gallery gallery,List<IFormFile> ProductImage)
        {
            string dosya = "";
            try
            {
                if(ProductImage.Count>0)
                {
                    foreach (var item in ProductImage)
                    {
                        string filename = item.FileName;
                        string uzanti = Path.GetExtension(filename);
                        string yeniisim = Guid.NewGuid().ToString() + uzanti;
                        string yol = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/Product_Images/" + yeniisim);
                        using(var stream=new FileStream(yol,FileMode.Create))
                        {
                            item.CopyToAsync(stream);
                        }
                        dosya += yeniisim+"-";
                    }
                }
                
            }
            catch (Exception ex)
            {

                throw;
            }

            if (ModelState.IsValid)
            {
                gallery.Image = dosya;
                _context.Add(gallery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Product_Id", "Product_Name", gallery.ProductId);
            return View(gallery);
        }

        // GET: Galleries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Galleries == null)
            {
                return NotFound();
            }

            var gallery = await _context.Galleries.FindAsync(id);
            if (gallery == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Product_Id", "Product_Name", gallery.ProductId);
            return View(gallery);
        }

        // POST: Galleries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GalleryId,ProductId,Image")] Gallery gallery)
        {
            if (id != gallery.GalleryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gallery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GalleryExists(gallery.GalleryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Product_Id", "Product_Name", gallery.ProductId);
            return View(gallery);
        }

        // GET: Galleries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Galleries == null)
            {
                return NotFound();
            }

            var gallery = await _context.Galleries
                .Include(g => g.Product)
                .FirstOrDefaultAsync(m => m.GalleryId == id);
            if (gallery == null)
            {
                return NotFound();
            }

            return View(gallery);
        }

        // POST: Galleries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Galleries == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Galleries'  is null.");
            }
            var gallery = await _context.Galleries.FindAsync(id);
            if (gallery != null)
            {
                _context.Galleries.Remove(gallery);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GalleryExists(int id)
        {
          return (_context.Galleries?.Any(e => e.GalleryId == id)).GetValueOrDefault();
        }
    }
}
