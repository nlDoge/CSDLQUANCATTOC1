using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLQUANCATTOC.Data;
using QLQUANCATTOC.Models;

namespace QLQUANCATTOC.Controllers
{
    public class PhanHoisController : Controller
    {
        private readonly quancattocContext _context;

        public PhanHoisController(quancattocContext context)
        {
            _context = context;
        }

        // GET: PhanHois
        public async Task<IActionResult> Index()
        {
            var quancattocContext = _context.PhanHois.Include(p => p.MaKhachHangNavigation);
            return View(await quancattocContext.ToListAsync());
        }

        // GET: PhanHois/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phanHoi = await _context.PhanHois
                .Include(p => p.MaKhachHangNavigation)
                .FirstOrDefaultAsync(m => m.MaPhanHoi == id);
            if (phanHoi == null)
            {
                return NotFound();
            }

            return View(phanHoi);
        }

        // GET: PhanHois/Create
        public IActionResult Create()
        {
            ViewData["MaKhachHang"] = new SelectList(_context.KhachHangs, "MaKhachHang", "MaKhachHang");
            return View();
        }

        // POST: PhanHois/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaPhanHoi,MaKhachHang,DanhGia,BinhLuan")] PhanHoi phanHoi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phanHoi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKhachHang"] = new SelectList(_context.KhachHangs, "MaKhachHang", "MaKhachHang", phanHoi.MaKhachHang);
            return View(phanHoi);
        }

        // GET: PhanHois/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phanHoi = await _context.PhanHois.FindAsync(id);
            if (phanHoi == null)
            {
                return NotFound();
            }
            ViewData["MaKhachHang"] = new SelectList(_context.KhachHangs, "MaKhachHang", "MaKhachHang", phanHoi.MaKhachHang);
            return View(phanHoi);
        }

        // POST: PhanHois/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaPhanHoi,MaKhachHang,DanhGia,BinhLuan")] PhanHoi phanHoi)
        {
            if (id != phanHoi.MaPhanHoi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phanHoi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhanHoiExists(phanHoi.MaPhanHoi))
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
            ViewData["MaKhachHang"] = new SelectList(_context.KhachHangs, "MaKhachHang", "MaKhachHang", phanHoi.MaKhachHang);
            return View(phanHoi);
        }

        // GET: PhanHois/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phanHoi = await _context.PhanHois
                .Include(p => p.MaKhachHangNavigation)
                .FirstOrDefaultAsync(m => m.MaPhanHoi == id);
            if (phanHoi == null)
            {
                return NotFound();
            }

            return View(phanHoi);
        }

        // POST: PhanHois/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var phanHoi = await _context.PhanHois.FindAsync(id);
            if (phanHoi != null)
            {
                _context.PhanHois.Remove(phanHoi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhanHoiExists(string id)
        {
            return _context.PhanHois.Any(e => e.MaPhanHoi == id);
        }
    }
}
