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
    public class ThanhToan1Controller : Controller
    {
        private readonly quancattocContext _context;

        public ThanhToan1Controller(quancattocContext context)
        {
            _context = context;
        }

        // GET: ThanhToan1
        public async Task<IActionResult> Index()
        {
            var quancattocContext = _context.ThanhToan1s.Include(t => t.MaCuaHangNavigation).Include(t => t.MaKhachHangNavigation);
            return View(await quancattocContext.ToListAsync());
        }

        // GET: ThanhToan1/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thanhToan1 = await _context.ThanhToan1s
                .Include(t => t.MaCuaHangNavigation)
                .Include(t => t.MaKhachHangNavigation)
                .FirstOrDefaultAsync(m => m.MaThanhToan == id);
            if (thanhToan1 == null)
            {
                return NotFound();
            }

            return View(thanhToan1);
        }

        // GET: ThanhToan1/Create
        public IActionResult Create()
        {
            ViewData["MaCuaHang"] = new SelectList(_context.CuaHangs, "MaCuaHang", "MaCuaHang");
            ViewData["MaKhachHang"] = new SelectList(_context.KhachHangs, "MaKhachHang", "MaKhachHang");
            return View();
        }

        // POST: ThanhToan1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaThanhToan,MaKhachHang,SoTienThanhToan,NgayThanhToan,PhuongThucThanhToan,MaCuaHang,TenCuaHang")] ThanhToan1 thanhToan1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thanhToan1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaCuaHang"] = new SelectList(_context.CuaHangs, "MaCuaHang", "MaCuaHang", thanhToan1.MaCuaHang);
            ViewData["MaKhachHang"] = new SelectList(_context.KhachHangs, "MaKhachHang", "MaKhachHang", thanhToan1.MaKhachHang);
            return View(thanhToan1);
        }

        // GET: ThanhToan1/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thanhToan1 = await _context.ThanhToan1s.FindAsync(id);
            if (thanhToan1 == null)
            {
                return NotFound();
            }
            ViewData["MaCuaHang"] = new SelectList(_context.CuaHangs, "MaCuaHang", "MaCuaHang", thanhToan1.MaCuaHang);
            ViewData["MaKhachHang"] = new SelectList(_context.KhachHangs, "MaKhachHang", "MaKhachHang", thanhToan1.MaKhachHang);
            return View(thanhToan1);
        }

        // POST: ThanhToan1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaThanhToan,MaKhachHang,SoTienThanhToan,NgayThanhToan,PhuongThucThanhToan,MaCuaHang,TenCuaHang")] ThanhToan1 thanhToan1)
        {
            if (id != thanhToan1.MaThanhToan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thanhToan1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThanhToan1Exists(thanhToan1.MaThanhToan))
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
            ViewData["MaCuaHang"] = new SelectList(_context.CuaHangs, "MaCuaHang", "MaCuaHang", thanhToan1.MaCuaHang);
            ViewData["MaKhachHang"] = new SelectList(_context.KhachHangs, "MaKhachHang", "MaKhachHang", thanhToan1.MaKhachHang);
            return View(thanhToan1);
        }

        // GET: ThanhToan1/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thanhToan1 = await _context.ThanhToan1s
                .Include(t => t.MaCuaHangNavigation)
                .Include(t => t.MaKhachHangNavigation)
                .FirstOrDefaultAsync(m => m.MaThanhToan == id);
            if (thanhToan1 == null)
            {
                return NotFound();
            }

            return View(thanhToan1);
        }

        // POST: ThanhToan1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var thanhToan1 = await _context.ThanhToan1s.FindAsync(id);
            if (thanhToan1 != null)
            {
                _context.ThanhToan1s.Remove(thanhToan1);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThanhToan1Exists(string id)
        {
            return _context.ThanhToan1s.Any(e => e.MaThanhToan == id);
        }
    }
}
