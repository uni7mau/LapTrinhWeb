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
    public class TVCLoaiSanPhamsController : Controller
    {
        private readonly AppDbContext _context;

        public TVCLoaiSanPhamsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TVCLoaiSanPhams
        public async Task<IActionResult> Index()
        {
            return View(await _context.TVCLoaiSanPhams.ToListAsync());
        }

        // GET: TVCLoaiSanPhams/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tVCLoaiSanPham = await _context.TVCLoaiSanPhams
                .FirstOrDefaultAsync(m => m.PVCId == id);
            if (tVCLoaiSanPham == null)
            {
                return NotFound();
            }

            return View(tVCLoaiSanPham);
        }

        // GET: TVCLoaiSanPhams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TVCLoaiSanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PVCId,TVCMaLoai,TVCTenLoai,TVCTrangThai")] TVCLoaiSanPham tVCLoaiSanPham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tVCLoaiSanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tVCLoaiSanPham);
        }

        // GET: TVCLoaiSanPhams/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tVCLoaiSanPham = await _context.TVCLoaiSanPhams.FindAsync(id);
            if (tVCLoaiSanPham == null)
            {
                return NotFound();
            }
            return View(tVCLoaiSanPham);
        }

        // POST: TVCLoaiSanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("PVCId,TVCMaLoai,TVCTenLoai,TVCTrangThai")] TVCLoaiSanPham tVCLoaiSanPham)
        {
            if (id != tVCLoaiSanPham.PVCId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tVCLoaiSanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TVCLoaiSanPhamExists(tVCLoaiSanPham.PVCId))
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
            return View(tVCLoaiSanPham);
        }

        // GET: TVCLoaiSanPhams/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tVCLoaiSanPham = await _context.TVCLoaiSanPhams
                .FirstOrDefaultAsync(m => m.PVCId == id);
            if (tVCLoaiSanPham == null)
            {
                return NotFound();
            }

            return View(tVCLoaiSanPham);
        }

        // POST: TVCLoaiSanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var tVCLoaiSanPham = await _context.TVCLoaiSanPhams.FindAsync(id);
            if (tVCLoaiSanPham != null)
            {
                _context.TVCLoaiSanPhams.Remove(tVCLoaiSanPham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TVCLoaiSanPhamExists(long id)
        {
            return _context.TVCLoaiSanPhams.Any(e => e.PVCId == id);
        }
    }
}
