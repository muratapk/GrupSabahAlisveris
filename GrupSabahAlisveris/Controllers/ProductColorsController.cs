using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GrupSabahAlisveris.Data;
using GrupSabahAlisveris.Models;

namespace GrupSabahAlisveris.Controllers
{
    public class ProductColorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductColorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductColors
        public async Task<IActionResult> Index(int? id)
        {
            var applicationDbContext = _context.ProductColors.Where(x=>x.ProductId==id).Include(p => p.Color).Include(p => p.Product);
            ViewBag.ProductId = id;
            //ViewData['Product']=id TempData['ProductId']=id
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProductColors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductColors == null)
            {
                return NotFound();
            }

            var productColor = await _context.ProductColors
                .Include(p => p.Color)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.ProductColorId == id);
            if (productColor == null)
            {
                return NotFound();
            }

            return View(productColor);
        }

        // GET: ProductColors/Create
        public IActionResult Create(int? id)
        {
            ViewData["ColorId"] = new SelectList(_context.Colors, "ColorId", "ColorName");
            //ViewData["ProductId"] = new SelectList(_context.Products, "Product_Id", "Product_Name");
            ViewData["ProductId"] = id;
            return View();
        }

        // POST: ProductColors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductColorId,ProductId,ColorId,Stocks")] ProductColor productColor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productColor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ColorId"] = new SelectList(_context.Colors, "ColorId", "ColorId", productColor.ColorId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Product_Id", "Product_Name", productColor.ProductId);
            return View(productColor);
        }

        // GET: ProductColors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductColors == null)
            {
                return NotFound();
            }

            var productColor = await _context.ProductColors.FindAsync(id);
            if (productColor == null)
            {
                return NotFound();
            }
            ViewData["ColorId"] = new SelectList(_context.Colors, "ColorId", "ColorId", productColor.ColorId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Product_Id", "Product_Name", productColor.ProductId);
            return View(productColor);
        }

        // POST: ProductColors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductColorId,ProductId,ColorId,Stocks")] ProductColor productColor)
        {
            if (id != productColor.ProductColorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productColor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductColorExists(productColor.ProductColorId))
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
            ViewData["ColorId"] = new SelectList(_context.Colors, "ColorId", "ColorId", productColor.ColorId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Product_Id", "Product_Name", productColor.ProductId);
            return View(productColor);
        }

        // GET: ProductColors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductColors == null)
            {
                return NotFound();
            }

            var productColor = await _context.ProductColors
                .Include(p => p.Color)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.ProductColorId == id);
            if (productColor == null)
            {
                return NotFound();
            }

            return View(productColor);
        }

        // POST: ProductColors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductColors == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProductColors'  is null.");
            }
            var productColor = await _context.ProductColors.FindAsync(id);
            if (productColor != null)
            {
                _context.ProductColors.Remove(productColor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductColorExists(int id)
        {
          return (_context.ProductColors?.Any(e => e.ProductColorId == id)).GetValueOrDefault();
        }
    }
}
