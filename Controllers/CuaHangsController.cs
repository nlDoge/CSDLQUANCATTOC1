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
    public class CuaHangsController : Controller
    {
        private readonly quancattocContext _context;

        public CuaHangsController(quancattocContext context)
        {
            _context = context;
        }

        // GET: CuaHangs
        public async Task<IActionResult> Index()
        {
            var quancattocContext = _context.CuaHangs.Include(c => c.MaNguoiQuanLyNavigation);
            return View(await quancattocContext.ToListAsync());
        }

        // GET: CuaHangs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuaHang = await _context.CuaHangs
                .Include(c => c.MaNguoiQuanLyNavigation)
                .FirstOrDefaultAsync(m => m.MaCuaHang == id);
            if (cuaHang == null)
            {
                return NotFound();
            }

            return View(cuaHang);
        }

        // GET: CuaHangs/Create
        public IActionResult Create()
        {
            ViewData["MaNguoiQuanLy"] = new SelectList(_context.QuanLies, "MaNguoiQuanLy", "MaNguoiQuanLy");
            return View();
        }

        // POST: CuaHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaCuaHang,TenCuaHang,DiaChi,Sdt,Email,MaNguoiQuanLy,GhiChu")] CuaHang cuaHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cuaHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaNguoiQuanLy"] = new SelectList(_context.QuanLies, "MaNguoiQuanLy", "MaNguoiQuanLy", cuaHang.MaNguoiQuanLy);
            return View(cuaHang);
        }

        // GET: CuaHangs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuaHang = await _context.CuaHangs.FindAsync(id);
            if (cuaHang == null)
            {
                return NotFound();
            }
            ViewData["MaNguoiQuanLy"] = new SelectList(_context.QuanLies, "MaNguoiQuanLy", "MaNguoiQuanLy", cuaHang.MaNguoiQuanLy);
            return View(cuaHang);
        }

        // POST: CuaHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaCuaHang,TenCuaHang,DiaChi,Sdt,Email,MaNguoiQuanLy,GhiChu")] CuaHang cuaHang)
        {
            if (id != cuaHang.MaCuaHang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cuaHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuaHangExists(cuaHang.MaCuaHang))
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
            ViewData["MaNguoiQuanLy"] = new SelectList(_context.QuanLies, "MaNguoiQuanLy", "MaNguoiQuanLy", cuaHang.MaNguoiQuanLy);
            return View(cuaHang);
        }

        // GET: CuaHangs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuaHang = await _context.CuaHangs
                .Include(c => c.MaNguoiQuanLyNavigation)
                .FirstOrDefaultAsync(m => m.MaCuaHang == id);
            if (cuaHang == null)
            {
                return NotFound();
            }

            return View(cuaHang);
        }

        // POST: CuaHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cuaHang = await _context.CuaHangs.FindAsync(id);
            if (cuaHang != null)
            {
                _context.CuaHangs.Remove(cuaHang);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CuaHangExists(string id)
        {
            return _context.CuaHangs.Any(e => e.MaCuaHang == id);
        }
    }
}
