using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using national.Models;
using nationalgame.context;

namespace national.Controllers
{
    public class MatchesController : Controller
    {
        private readonly dbcontext _context;

        public MatchesController(dbcontext context)
        {
            _context = context;
        }

        // GET: Matches
        public async Task<IActionResult> Index()
        {
            var dbcontext = _context.Matches.Include(m => m.Game).Include(m => m.TeamA).Include(m => m.TeamB);
            return View(await dbcontext.ToListAsync());
        }

        // GET: Matches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Matches
                .Include(m => m.Game)
                .Include(m => m.TeamA)
                .Include(m => m.TeamB)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // GET: Matches/Create
        public IActionResult Create()
        {
            ViewData["GameId"] = new SelectList(_context.Games, "Id", "Name");
            ViewData["TeamAId"] = new SelectList(_context.Teams, "Id", "Name");
            ViewData["TeamBId"] = new SelectList(_context.Teams, "Id", "Name");
            return View();
        }

        // POST: Matches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MatchDate,Location,DurationMinutes,TeamAId,TeamBId,GameId")] Match match)
        {
         
                _context.Add(match);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
          
            ViewData["GameId"] = new SelectList(_context.Games, "Id", "Name", match.GameId);
            ViewData["TeamAId"] = new SelectList(_context.Teams, "Id", "Name", match.TeamAId);
            ViewData["TeamBId"] = new SelectList(_context.Teams, "Id", "Name", match.TeamBId);
            return View(match);
        }

        // GET: Matches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Matches.FindAsync(id);
            if (match == null)
            {
                return NotFound();
            }
            ViewData["GameId"] = new SelectList(_context.Games, "Id", "Name", match.GameId);
            ViewData["TeamAId"] = new SelectList(_context.Teams, "Id", "Name", match.TeamAId);
            ViewData["TeamBId"] = new SelectList(_context.Teams, "Id", "Name", match.TeamBId);
            return View(match);
        }

        // POST: Matches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MatchDate,Location,DurationMinutes,TeamAId,TeamBId,GameId")] Match match)
        {
            if (id != match.Id)
            {
                return NotFound();
            }

          
                try
                {
                    _context.Update(match);
                    await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            catch (DbUpdateConcurrencyException)
                {
                    if (!MatchExists(match.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
             
          }
            ViewData["GameId"] = new SelectList(_context.Games, "Id", "Name", match.GameId);
            ViewData["TeamAId"] = new SelectList(_context.Teams, "Id", "Name", match.TeamAId);
            ViewData["TeamBId"] = new SelectList(_context.Teams, "Id", "Name", match.TeamBId);
            return View(match);
        }

        // GET: Matches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Matches
                .Include(m => m.Game)
                .Include(m => m.TeamA)
                .Include(m => m.TeamB)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // POST: Matches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var match = await _context.Matches.FindAsync(id);
            if (match != null)
            {
                _context.Matches.Remove(match);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatchExists(int id)
        {
            return _context.Matches.Any(e => e.Id == id);
        }
    }
}
