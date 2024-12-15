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
    public class LichHensController : Controller
    {
        private readonly quancattocContext _context;

        public LichHensController(quancattocContext context)
        {
            _context = context;
        }

        // GET: LichHens
        public async Task<IActionResult> Index()
        {
            var quancattocContext = _context.LichHens.Include(l => l.MaDichVuNavigation).Include(l => l.MaKhachHangNavigation).Include(l => l.MaNhanVienNavigation);
            return View(await quancattocContext.ToListAsync());
        }

        // GET: LichHens/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lichHen = await _context.LichHens
                .Include(l => l.MaDichVuNavigation)
                .Include(l => l.MaKhachHangNavigation)
                .Include(l => l.MaNhanVienNavigation)
                .FirstOrDefaultAsync(m => m.MaLichHen == id);
            if (lichHen == null)
            {
                return NotFound();
            }

            return View(lichHen);
        }

        // GET: LichHens/Create
        public IActionResult Create()
        {
            ViewData["MaDichVu"] = new SelectList(_context.DichVus, "MaDichVu", "MaDichVu");
            ViewData["MaKhachHang"] = new SelectList(_context.KhachHangs, "MaKhachHang", "MaKhachHang");
            ViewData["MaNhanVien"] = new SelectList(_context.NhanViens, "MaNhanVien", "MaNhanVien");
            return View();
        }

        // POST: LichHens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaLichHen,MaKhachHang,MaNhanVien,MaDichVu,LichHen1,GhiChu")] LichHen lichHen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lichHen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaDichVu"] = new SelectList(_context.DichVus, "MaDichVu", "MaDichVu", lichHen.MaDichVu);
            ViewData["MaKhachHang"] = new SelectList(_context.KhachHangs, "MaKhachHang", "MaKhachHang", lichHen.MaKhachHang);
            ViewData["MaNhanVien"] = new SelectList(_context.NhanViens, "MaNhanVien", "MaNhanVien", lichHen.MaNhanVien);
            return View(lichHen);
        }

        // GET: LichHens/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lichHen = await _context.LichHens.FindAsync(id);
            if (lichHen == null)
            {
                return NotFound();
            }
            ViewData["MaDichVu"] = new SelectList(_context.DichVus, "MaDichVu", "MaDichVu", lichHen.MaDichVu);
            ViewData["MaKhachHang"] = new SelectList(_context.KhachHangs, "MaKhachHang", "MaKhachHang", lichHen.MaKhachHang);
            ViewData["MaNhanVien"] = new SelectList(_context.NhanViens, "MaNhanVien", "MaNhanVien", lichHen.MaNhanVien);
            return View(lichHen);
        }

        // POST: LichHens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaLichHen,MaKhachHang,MaNhanVien,MaDichVu,LichHen1,GhiChu")] LichHen lichHen)
        {
            if (id != lichHen.MaLichHen)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lichHen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LichHenExists(lichHen.MaLichHen))
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
            ViewData["MaDichVu"] = new SelectList(_context.DichVus, "MaDichVu", "MaDichVu", lichHen.MaDichVu);
            ViewData["MaKhachHang"] = new SelectList(_context.KhachHangs, "MaKhachHang", "MaKhachHang", lichHen.MaKhachHang);
            ViewData["MaNhanVien"] = new SelectList(_context.NhanViens, "MaNhanVien", "MaNhanVien", lichHen.MaNhanVien);
            return View(lichHen);
        }

        // GET: LichHens/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lichHen = await _context.LichHens
                .Include(l => l.MaDichVuNavigation)
                .Include(l => l.MaKhachHangNavigation)
                .Include(l => l.MaNhanVienNavigation)
                .FirstOrDefaultAsync(m => m.MaLichHen == id);
            if (lichHen == null)
            {
                return NotFound();
            }

            return View(lichHen);
        }

        // POST: LichHens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var lichHen = await _context.LichHens.FindAsync(id);
            if (lichHen != null)
            {
                _context.LichHens.Remove(lichHen);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LichHenExists(string id)
        {
            return _context.LichHens.Any(e => e.MaLichHen == id);
        }
    }
}
