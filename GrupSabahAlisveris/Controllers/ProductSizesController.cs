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
    public class ProductSizesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductSizesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductSizes
        public async Task<IActionResult> Index(int?id)
        {
            var applicationDbContext = _context.ProductSizes.Where(x=>x.ProductId==id).Include(p => p.Product).Include(p => p.Size);
            ViewBag.ProductId = id;
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProductSizes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductSizes == null)
            {
                return NotFound();
            }

            var productSize = await _context.ProductSizes
                .Include(p => p.Product)
                .Include(p => p.Size)
                .FirstOrDefaultAsync(m => m.ProductSizeId == id);
            if (productSize == null)
            {
                return NotFound();
            }

            return View(productSize);
        }

        // GET: ProductSizes/Create
        public IActionResult Create(int ? id)
        {
            //ViewData["ProductId"] = new SelectList(_context.Products, "Product_Id", "Product_Name");
            ViewBag.ProductId = id;
            ViewData["SizeId"] = new SelectList(_context.Sizes, "SizeId", "SizeId");
            return View();
        }

        // POST: ProductSizes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductSizeId,ProductId,SizeId,Stocks")] ProductSize productSize)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productSize);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Product_Id", "Product_Name", productSize.ProductId);
            ViewData["SizeId"] = new SelectList(_context.Sizes, "SizeId", "SizeId", productSize.SizeId);
            return View(productSize);
        }

        // GET: ProductSizes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductSizes == null)
            {
                return NotFound();
            }

            var productSize = await _context.ProductSizes.FindAsync(id);
            if (productSize == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Product_Id", "Product_Name", productSize.ProductId);
            ViewData["SizeId"] = new SelectList(_context.Sizes, "SizeId", "SizeId", productSize.SizeId);
            return View(productSize);
        }

        // POST: ProductSizes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductSizeId,ProductId,SizeId,Stocks")] ProductSize productSize)
        {
            if (id != productSize.ProductSizeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productSize);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductSizeExists(productSize.ProductSizeId))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "Product_Id", "Product_Name", productSize.ProductId);
            ViewData["SizeId"] = new SelectList(_context.Sizes, "SizeId", "SizeId", productSize.SizeId);
            return View(productSize);
        }

        // GET: ProductSizes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductSizes == null)
            {
                return NotFound();
            }

            var productSize = await _context.ProductSizes
                .Include(p => p.Product)
                .Include(p => p.Size)
                .FirstOrDefaultAsync(m => m.ProductSizeId == id);
            if (productSize == null)
            {
                return NotFound();
            }

            return View(productSize);
        }

        // POST: ProductSizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductSizes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProductSizes'  is null.");
            }
            var productSize = await _context.ProductSizes.FindAsync(id);
            if (productSize != null)
            {
                _context.ProductSizes.Remove(productSize);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductSizeExists(int id)
        {
          return (_context.ProductSizes?.Any(e => e.ProductSizeId == id)).GetValueOrDefault();
        }
    }
}
