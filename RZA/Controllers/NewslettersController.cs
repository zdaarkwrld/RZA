using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RZA.Data;
using RZA.Models;

namespace RZA.Controllers
{
    public class NewslettersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NewslettersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Newsletters
        public async Task<IActionResult> Index()
        {
              return _context.Newsletters != null ? 
                          View(await _context.Newsletters.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Newsletters'  is null.");
        }

        // GET: Newsletters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Newsletters == null)
            {
                return NotFound();
            }

            var newsletters = await _context.Newsletters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (newsletters == null)
            {
                return NotFound();
            }

            return View(newsletters);
        }

        // GET: Newsletters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Newsletters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Created_At,Updated_At,Comments")] Newsletters newsletters)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newsletters);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newsletters);
        }

        // GET: Newsletters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Newsletters == null)
            {
                return NotFound();
            }

            var newsletters = await _context.Newsletters.FindAsync(id);
            if (newsletters == null)
            {
                return NotFound();
            }
            return View(newsletters);
        }

        // POST: Newsletters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,Created_At,Updated_At,Comments")] Newsletters newsletters)
        {
            if (id != newsletters.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newsletters);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewslettersExists(newsletters.Id))
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
            return View(newsletters);
        }

        // GET: Newsletters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Newsletters == null)
            {
                return NotFound();
            }

            var newsletters = await _context.Newsletters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (newsletters == null)
            {
                return NotFound();
            }

            return View(newsletters);
        }

        // POST: Newsletters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Newsletters == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Newsletters'  is null.");
            }
            var newsletters = await _context.Newsletters.FindAsync(id);
            if (newsletters != null)
            {
                _context.Newsletters.Remove(newsletters);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewslettersExists(int id)
        {
          return (_context.Newsletters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
