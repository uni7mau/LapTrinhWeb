using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NguyenDucThach_231230898_de02.Entities;
using NguyenDucThach_231230898_de02.Models;

namespace NguyenDucThach_231230898_de02.Controllers
{
    public class NguyenDucThachCatalogsController : Controller
    {
        private readonly AppDbContext _context;

        public NguyenDucThachCatalogsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: NguyenDucThachCatalogs
        public async Task<IActionResult> ndtIndex()
        {
            return View(await _context.NguyenDucThachCatalogs.ToListAsync());
        }

        // GET: NguyenDucThachCatalogs/Details/5
        public async Task<IActionResult> ndtDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguyenDucThachCatalog = await _context.NguyenDucThachCatalogs
                .FirstOrDefaultAsync(m => m.hvtId == id);
            if (nguyenDucThachCatalog == null)
            {
                return NotFound();
            }

            return View(nguyenDucThachCatalog);
        }

        // GET: NguyenDucThachCatalogs/Create
        public IActionResult ndtCreate()
        {
            return View();
        }

        // POST: NguyenDucThachCatalogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ndtCreate([Bind("hvtId,hvtCateName,hvtCatePrice,hvtCateQty,hvtPicture,hvtCateActive")] NguyenDucThachCatalog nguyenDucThachCatalog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nguyenDucThachCatalog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nguyenDucThachCatalog);
        }

        // GET: NguyenDucThachCatalogs/Edit/5
        public async Task<IActionResult> ndtEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguyenDucThachCatalog = await _context.NguyenDucThachCatalogs.FindAsync(id);
            if (nguyenDucThachCatalog == null)
            {
                return NotFound();
            }
            return View(nguyenDucThachCatalog);
        }

        // POST: NguyenDucThachCatalogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ndtEdit(int id, [Bind("hvtId,hvtCateName,hvtCatePrice,hvtCateQty,hvtPicture,hvtCateActive")] NguyenDucThachCatalog nguyenDucThachCatalog)
        {
            if (id != nguyenDucThachCatalog.hvtId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nguyenDucThachCatalog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NguyenDucThachCatalogExists(nguyenDucThachCatalog.hvtId))
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
            return View(nguyenDucThachCatalog);
        }

        // GET: NguyenDucThachCatalogs/Delete/5
        public async Task<IActionResult> ndtDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguyenDucThachCatalog = await _context.NguyenDucThachCatalogs
                .FirstOrDefaultAsync(m => m.hvtId == id);
            if (nguyenDucThachCatalog == null)
            {
                return NotFound();
            }

            return View(nguyenDucThachCatalog);
        }

        // POST: NguyenDucThachCatalogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ndtDeleteConfirmed(int id)
        {
            var nguyenDucThachCatalog = await _context.NguyenDucThachCatalogs.FindAsync(id);
            if (nguyenDucThachCatalog != null)
            {
                _context.NguyenDucThachCatalogs.Remove(nguyenDucThachCatalog);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NguyenDucThachCatalogExists(int id)
        {
            return _context.NguyenDucThachCatalogs.Any(e => e.hvtId == id);
        }
    }
}
