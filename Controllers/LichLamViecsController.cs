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
    public class LichLamViecsController : Controller
    {
        private readonly quancattocContext _context;

        public LichLamViecsController(quancattocContext context)
        {
            _context = context;
        }

        // GET: LichLamViecs
        public async Task<IActionResult> Index()
        {
            return View(await _context.LichLamViecs.ToListAsync());
        }

        // GET: LichLamViecs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lichLamViec = await _context.LichLamViecs
                .FirstOrDefaultAsync(m => m.MaCaLam == id);
            if (lichLamViec == null)
            {
                return NotFound();
            }

            return View(lichLamViec);
        }

        // GET: LichLamViecs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LichLamViecs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaCaLam,NgayLamViec,Ca")] LichLamViec lichLamViec)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lichLamViec);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lichLamViec);
        }

        // GET: LichLamViecs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lichLamViec = await _context.LichLamViecs.FindAsync(id);
            if (lichLamViec == null)
            {
                return NotFound();
            }
            return View(lichLamViec);
        }

        // POST: LichLamViecs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaCaLam,NgayLamViec,Ca")] LichLamViec lichLamViec)
        {
            if (id != lichLamViec.MaCaLam)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lichLamViec);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LichLamViecExists(lichLamViec.MaCaLam))
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
            return View(lichLamViec);
        }

        // GET: LichLamViecs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lichLamViec = await _context.LichLamViecs
                .FirstOrDefaultAsync(m => m.MaCaLam == id);
            if (lichLamViec == null)
            {
                return NotFound();
            }

            return View(lichLamViec);
        }

        // POST: LichLamViecs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var lichLamViec = await _context.LichLamViecs.FindAsync(id);
            if (lichLamViec != null)
            {
                _context.LichLamViecs.Remove(lichLamViec);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LichLamViecExists(string id)
        {
            return _context.LichLamViecs.Any(e => e.MaCaLam == id);
        }
    }
}
