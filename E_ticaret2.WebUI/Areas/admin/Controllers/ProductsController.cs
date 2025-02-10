﻿using E_ticaret2.Core.Entities;
using E_ticaret2.Data;
using E_ticaret2.WebUI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace E_ticaret2.WebUI.Areas.admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class ProductsController : Controller
    {
        private readonly DatabaseContext _context;

        public ProductsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: admin/Products
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.Products.Include(p => p.Brand).Include(p => p.Category);
            return View(await databaseContext.ToListAsync());
        }

        // GET: admin/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: admin/Products/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, IFormFile? Image, IFormFile? HelperImage1, IFormFile? HelperImage2, IFormFile? HelperImage3)
        {
            if (ModelState.IsValid)
            {
                // Eğer DiscountRate boşsa ve DiscountedPrice doluysa, indirim oranını hesapla
                if (!product.DiscountRate.HasValue && product.DiscountedPrice.HasValue)
                {
                    product.DiscountRate = (int)(100 * (1 - (product.DiscountedPrice.Value / product.Price)));
                }
                // Eğer DiscountedPrice boşsa ve DiscountRate doluysa, yeni indirimli fiyatı hesapla
                else if ((!product.DiscountedPrice.HasValue && product.DiscountRate.HasValue) || (product.DiscountedPrice.HasValue && product.DiscountRate.HasValue))
                {
                    product.DiscountedPrice = product.Price * (1 - (product.DiscountRate.Value / 100m));
                }

                product.Image = await FileHelper.FileLoaderAsync(Image, "/Img/Products/");
                product.HelperImage1 = await FileHelper.FileLoaderAsync(HelperImage1, "/Img/Products/");
                product.HelperImage2 = await FileHelper.FileLoaderAsync(HelperImage2, "/Img/Products/");
                product.HelperImage3 = await FileHelper.FileLoaderAsync(HelperImage3, "/Img/Products/");



                await _context.AddAsync(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name", product.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: admin/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name", product.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product, IFormFile? Image, IFormFile? HelperImage1, IFormFile? HelperImage2, IFormFile? HelperImage3, bool cbResmiSil = false)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (!product.DiscountRate.HasValue && product.DiscountedPrice.HasValue)
                    {
                        product.DiscountRate = (int)(100 * (1 - (product.DiscountedPrice.Value / product.Price)));
                    }
                    // Eğer DiscountedPrice boşsa ve DiscountRate doluysa, yeni indirimli fiyatı hesapla
                    else if ((!product.DiscountedPrice.HasValue && product.DiscountRate.HasValue) || (product.DiscountedPrice.HasValue && product.DiscountRate.HasValue))
                    {
                        product.DiscountedPrice = product.Price * (1 - (product.DiscountRate.Value / 100m));
                    }
                    if (cbResmiSil)
                    {
                        product.Image = string.Empty;

                    }
                    if (Image is not null)
                        product.Image = await FileHelper.FileLoaderAsync(Image, "/Img/Products/");

                    if (HelperImage1 is not null)
                        product.HelperImage1 = await FileHelper.FileLoaderAsync(HelperImage1, "/Img/Products/");

                    if (HelperImage2 is not null)
                        product.HelperImage2 = await FileHelper.FileLoaderAsync(HelperImage2, "/Img/Products/");

                    if (HelperImage3 is not null)
                        product.HelperImage3 = await FileHelper.FileLoaderAsync(HelperImage3, "/Img/Products/");

                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name", product.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: admin/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                if (!string.IsNullOrEmpty(product.Image))
                {
                    FileHelper.FileRemover(product.Image, "/Img/Products/");
                }
                _context.Products.Remove(product);
                
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
