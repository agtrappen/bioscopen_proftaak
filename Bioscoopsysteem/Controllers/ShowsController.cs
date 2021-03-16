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
    public class ShowsController : Controller
    {
        private readonly BioscoopsysteemContext _context;

        public ShowsController(BioscoopsysteemContext context)
        {
            _context = context;
        }

        // GET: Shows
        public async Task<IActionResult> Index(string? timeFrames, string? genre)
        {
            var shows = _context.Shows
                .Include(s => s.Movie)
                .AsNoTracking();

            var currentTime = DateTime.Now;

            switch (timeFrames)
            {
                case "twoHours":
                    DateTime twoHourTimeFrame = currentTime.AddHours(2);                 
                    shows = shows.OrderBy(s=>s.Start_date).Where(s => s.Start_date <= twoHourTimeFrame);                  
                    break;
                case "fourHours":                               
                    DateTime fourHourTimeFrame = currentTime.AddHours(4);                  
                    shows = shows.OrderBy(s => s.Start_date).Where(s => s.Start_date <= fourHourTimeFrame);
                    break;
                default:
                    shows = shows.OrderBy(s => s.Start_date);
                    break;
            }

            if (genre != null)
            {
                shows = shows.OrderBy(s => s.Start_date).Where(s => s.Movie.Genre == genre);
            }

            return View(await shows.ToListAsync());
        }
        public async Task<IActionResult> IndexCurrentMovieWeek()
        {
            var shows = _context.Shows
                .Include(s => s.Movie)
                .AsNoTracking();

            DateTime today = DateTime.Today;
            int daysUntilMonday = ((int)DayOfWeek.Monday - (int)today.DayOfWeek + 7) % 7;
            DateTime lastmonday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
            DateTime nextMonday = today.AddDays(daysUntilMonday);

            shows = shows.OrderBy(s => s.Start_date).Where(s => (s.Start_date >= lastmonday) && (s.Start_date <= nextMonday));

            return View(await shows.ToListAsync());
        }


        // GET: Shows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Shows
                .FirstOrDefaultAsync(m => m.ShowId == id);
            if (show == null)
            {
                return NotFound();
            }

            return View(show);
        }

        // GET: Shows/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShowId,Start_date,HallId,MovieId,Ticket_price")] Show show)
        {
            if (ModelState.IsValid)
            {
                _context.Add(show);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(show);
        }

        // GET: Shows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Shows.FindAsync(id);
            if (show == null)
            {
                return NotFound();
            }
            return View(show);
        }

        // POST: Shows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShowId,Start_date,HallId,MovieId,Ticket_price")] Show show)
        {
            if (id != show.ShowId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(show);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowExists(show.ShowId))
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
            return View(show);
        }

        // GET: Shows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Shows
                .FirstOrDefaultAsync(m => m.ShowId == id);
            if (show == null)
            {
                return NotFound();
            }

            return View(show);
        }

        // POST: Shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var show = await _context.Shows.FindAsync(id);
            _context.Shows.Remove(show);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShowExists(int id)
        {
            return _context.Shows.Any(e => e.ShowId == id);
        }


    }
}
