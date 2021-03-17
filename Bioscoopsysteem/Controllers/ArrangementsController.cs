using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bioscoopsysteem.Data;
using Bioscoopsysteem.Models;

namespace Bioscoopsysteem.Controllers
{
    public class ArrangementsController : Controller
    {
        private readonly BioscoopsysteemContext _context;

        public ArrangementsController(BioscoopsysteemContext context)
        {
            _context = context;
        }

        // GET: Arrangements
        public async Task<IActionResult> Index()
        {
            return View(await _context.Arrangements.ToListAsync());
        }

        // GET: Arrangements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arrangement = await _context.Arrangements
                .FirstOrDefaultAsync(m => m.ArrangementId == id);
            if (arrangement == null)
            {
                return NotFound();
            }

            return View(arrangement);
        }

        // GET: Arrangements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Arrangements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArrangementId,Description,Price")] Arrangement arrangement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(arrangement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(arrangement);
        }

        // GET: Arrangements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arrangement = await _context.Arrangements.FindAsync(id);
            if (arrangement == null)
            {
                return NotFound();
            }
            return View(arrangement);
        }

        // POST: Arrangements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArrangementId,Description,Price")] Arrangement arrangement)
        {
            if (id != arrangement.ArrangementId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arrangement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArrangementExists(arrangement.ArrangementId))
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
            return View(arrangement);
        }

        // GET: Arrangements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arrangement = await _context.Arrangements
                .FirstOrDefaultAsync(m => m.ArrangementId == id);
            if (arrangement == null)
            {
                return NotFound();
            }

            return View(arrangement);
        }

        // POST: Arrangements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var arrangement = await _context.Arrangements.FindAsync(id);
            _context.Arrangements.Remove(arrangement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArrangementExists(int id)
        {
            return _context.Arrangements.Any(e => e.ArrangementId == id);
        }
    }
}
