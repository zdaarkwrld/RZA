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
    public class Loyalty_ProgramsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Loyalty_ProgramsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Loyalty_Programs
        public async Task<IActionResult> Index()
        {
              return _context.Loyalty_Programs != null ? 
                          View(await _context.Loyalty_Programs.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Loyalty_Programs'  is null.");
        }

        // GET: Loyalty_Programs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Loyalty_Programs == null)
            {
                return NotFound();
            }

            var loyalty_Programs = await _context.Loyalty_Programs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loyalty_Programs == null)
            {
                return NotFound();
            }

            return View(loyalty_Programs);
        }

        // GET: Loyalty_Programs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Loyalty_Programs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Points_Required,Reward,Created_At,Updated_At")] Loyalty_Programs loyalty_Programs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loyalty_Programs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loyalty_Programs);
        }

        // GET: Loyalty_Programs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Loyalty_Programs == null)
            {
                return NotFound();
            }

            var loyalty_Programs = await _context.Loyalty_Programs.FindAsync(id);
            if (loyalty_Programs == null)
            {
                return NotFound();
            }
            return View(loyalty_Programs);
        }

        // POST: Loyalty_Programs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Points_Required,Reward,Created_At,Updated_At")] Loyalty_Programs loyalty_Programs)
        {
            if (id != loyalty_Programs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loyalty_Programs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Loyalty_ProgramsExists(loyalty_Programs.Id))
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
            return View(loyalty_Programs);
        }

        // GET: Loyalty_Programs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Loyalty_Programs == null)
            {
                return NotFound();
            }

            var loyalty_Programs = await _context.Loyalty_Programs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loyalty_Programs == null)
            {
                return NotFound();
            }

            return View(loyalty_Programs);
        }

        // POST: Loyalty_Programs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Loyalty_Programs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Loyalty_Programs'  is null.");
            }
            var loyalty_Programs = await _context.Loyalty_Programs.FindAsync(id);
            if (loyalty_Programs != null)
            {
                _context.Loyalty_Programs.Remove(loyalty_Programs);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Loyalty_ProgramsExists(int id)
        {
          return (_context.Loyalty_Programs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
