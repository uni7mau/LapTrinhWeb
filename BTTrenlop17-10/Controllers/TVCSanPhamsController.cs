using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTTrenlop17_10.Entities;
using BTTrenlop17_10.Models;

namespace BTTrenlop17_10.Controllers
{
    public class TVCSanPhamsController : Controller
    {
        private readonly AppDbContext _context;

        public TVCSanPhamsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TVCSanPhams
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.TVCSanPhams.Include(t => t.TVCLoaiSanPham);
            return View(await appDbContext.ToListAsync());
        }

        // GET: TVCSanPhams/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tVCSanPham = await _context.TVCSanPhams
                .Include(t => t.TVCLoaiSanPham)
                .FirstOrDefaultAsync(m => m.TVCId == id);
            if (tVCSanPham == null)
            {
                return NotFound();
            }

            return View(tVCSanPham);
        }

        // GET: TVCSanPhams/Create
        public IActionResult Create()
        {
            ViewData["TVCLoaiSanPhamId"] = new SelectList(_context.TVCLoaiSanPhams, "PVCId", "PVCId");
            return View();
        }

        // POST: TVCSanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TVCId,TVCMasanPham,TVCTenSanPham,TVCHinhAnh,TVCSoLuong,TVCDonGia,TVCLoaiSanPhamId")] TVCSanPham tVCSanPham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tVCSanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TVCLoaiSanPhamId"] = new SelectList(_context.TVCLoaiSanPhams, "PVCId", "PVCId", tVCSanPham.TVCLoaiSanPhamId);
            return View(tVCSanPham);
        }

        // GET: TVCSanPhams/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tVCSanPham = await _context.TVCSanPhams.FindAsync(id);
            if (tVCSanPham == null)
            {
                return NotFound();
            }
            ViewData["TVCLoaiSanPhamId"] = new SelectList(_context.TVCLoaiSanPhams, "PVCId", "PVCId", tVCSanPham.TVCLoaiSanPhamId);
            return View(tVCSanPham);
        }

        // POST: TVCSanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("TVCId,TVCMasanPham,TVCTenSanPham,TVCHinhAnh,TVCSoLuong,TVCDonGia,TVCLoaiSanPhamId")] TVCSanPham tVCSanPham)
        {
            if (id != tVCSanPham.TVCId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tVCSanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TVCSanPhamExists(tVCSanPham.TVCId))
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
            ViewData["TVCLoaiSanPhamId"] = new SelectList(_context.TVCLoaiSanPhams, "PVCId", "PVCId", tVCSanPham.TVCLoaiSanPhamId);
            return View(tVCSanPham);
        }

        // GET: TVCSanPhams/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tVCSanPham = await _context.TVCSanPhams
                .Include(t => t.TVCLoaiSanPham)
                .FirstOrDefaultAsync(m => m.TVCId == id);
            if (tVCSanPham == null)
            {
                return NotFound();
            }

            return View(tVCSanPham);
        }

        // POST: TVCSanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var tVCSanPham = await _context.TVCSanPhams.FindAsync(id);
            if (tVCSanPham != null)
            {
                _context.TVCSanPhams.Remove(tVCSanPham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TVCSanPhamExists(long id)
        {
            return _context.TVCSanPhams.Any(e => e.TVCId == id);
        }
    }
}
