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
    public class NhanVienLichLamViecsController : Controller
    {
        private readonly quancattocContext _context;

        public NhanVienLichLamViecsController(quancattocContext context)
        {
            _context = context;
        }

        // GET: NhanVienLichLamViecs
        public async Task<IActionResult> Index()
        {
            var quancattocContext = _context.NhanVienLichLamViecs.Include(n => n.MaCaLamNavigation).Include(n => n.MaNhanVienNavigation);
            return View(await quancattocContext.ToListAsync());
        }

        // GET: NhanVienLichLamViecs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVienLichLamViec = await _context.NhanVienLichLamViecs
                .Include(n => n.MaCaLamNavigation)
                .Include(n => n.MaNhanVienNavigation)
                .FirstOrDefaultAsync(m => m.MaNhanVien == id);
            if (nhanVienLichLamViec == null)
            {
                return NotFound();
            }

            return View(nhanVienLichLamViec);
        }

        // GET: NhanVienLichLamViecs/Create
        public IActionResult Create()
        {
            ViewData["MaCaLam"] = new SelectList(_context.LichLamViecs, "MaCaLam", "MaCaLam");
            ViewData["MaNhanVien"] = new SelectList(_context.NhanViens, "MaNhanVien", "MaNhanVien");
            return View();
        }

        // POST: NhanVienLichLamViecs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNhanVien,MaCaLam,Mota")] NhanVienLichLamViec nhanVienLichLamViec)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanVienLichLamViec);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaCaLam"] = new SelectList(_context.LichLamViecs, "MaCaLam", "MaCaLam", nhanVienLichLamViec.MaCaLam);
            ViewData["MaNhanVien"] = new SelectList(_context.NhanViens, "MaNhanVien", "MaNhanVien", nhanVienLichLamViec.MaNhanVien);
            return View(nhanVienLichLamViec);
        }

        // GET: NhanVienLichLamViecs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVienLichLamViec = await _context.NhanVienLichLamViecs.FindAsync(id);
            if (nhanVienLichLamViec == null)
            {
                return NotFound();
            }
            ViewData["MaCaLam"] = new SelectList(_context.LichLamViecs, "MaCaLam", "MaCaLam", nhanVienLichLamViec.MaCaLam);
            ViewData["MaNhanVien"] = new SelectList(_context.NhanViens, "MaNhanVien", "MaNhanVien", nhanVienLichLamViec.MaNhanVien);
            return View(nhanVienLichLamViec);
        }

        // POST: NhanVienLichLamViecs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaNhanVien,MaCaLam,Mota")] NhanVienLichLamViec nhanVienLichLamViec)
        {
            if (id != nhanVienLichLamViec.MaNhanVien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanVienLichLamViec);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanVienLichLamViecExists(nhanVienLichLamViec.MaNhanVien))
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
            ViewData["MaCaLam"] = new SelectList(_context.LichLamViecs, "MaCaLam", "MaCaLam", nhanVienLichLamViec.MaCaLam);
            ViewData["MaNhanVien"] = new SelectList(_context.NhanViens, "MaNhanVien", "MaNhanVien", nhanVienLichLamViec.MaNhanVien);
            return View(nhanVienLichLamViec);
        }

        // GET: NhanVienLichLamViecs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVienLichLamViec = await _context.NhanVienLichLamViecs
                .Include(n => n.MaCaLamNavigation)
                .Include(n => n.MaNhanVienNavigation)
                .FirstOrDefaultAsync(m => m.MaNhanVien == id);
            if (nhanVienLichLamViec == null)
            {
                return NotFound();
            }

            return View(nhanVienLichLamViec);
        }

        // POST: NhanVienLichLamViecs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var nhanVienLichLamViec = await _context.NhanVienLichLamViecs.FindAsync(id);
            if (nhanVienLichLamViec != null)
            {
                _context.NhanVienLichLamViecs.Remove(nhanVienLichLamViec);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanVienLichLamViecExists(string id)
        {
            return _context.NhanVienLichLamViecs.Any(e => e.MaNhanVien == id);
        }
    }
}
