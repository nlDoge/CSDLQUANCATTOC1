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
    public class QuanLiesController : Controller
    {
        private readonly quancattocContext _context;

        public QuanLiesController(quancattocContext context)
        {
            _context = context;
        }

        // GET: QuanLies
        public async Task<IActionResult> Index()
        {
            return View(await _context.QuanLies.ToListAsync());
        }

        // GET: QuanLies/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quanLy = await _context.QuanLies
                .FirstOrDefaultAsync(m => m.MaNguoiQuanLy == id);
            if (quanLy == null)
            {
                return NotFound();
            }

            return View(quanLy);
        }

        // GET: QuanLies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QuanLies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNguoiQuanLy,TenNguoiQuanLy,Sdt,Email,DiaChi")] QuanLy quanLy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quanLy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quanLy);
        }

        // GET: QuanLies/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quanLy = await _context.QuanLies.FindAsync(id);
            if (quanLy == null)
            {
                return NotFound();
            }
            return View(quanLy);
        }

        // POST: QuanLies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaNguoiQuanLy,TenNguoiQuanLy,Sdt,Email,DiaChi")] QuanLy quanLy)
        {
            if (id != quanLy.MaNguoiQuanLy)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quanLy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuanLyExists(quanLy.MaNguoiQuanLy))
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
            return View(quanLy);
        }

        // GET: QuanLies/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quanLy = await _context.QuanLies
                .FirstOrDefaultAsync(m => m.MaNguoiQuanLy == id);
            if (quanLy == null)
            {
                return NotFound();
            }

            return View(quanLy);
        }

        // POST: QuanLies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var quanLy = await _context.QuanLies.FindAsync(id);
            if (quanLy != null)
            {
                _context.QuanLies.Remove(quanLy);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuanLyExists(string id)
        {
            return _context.QuanLies.Any(e => e.MaNguoiQuanLy == id);
        }
    }
}
