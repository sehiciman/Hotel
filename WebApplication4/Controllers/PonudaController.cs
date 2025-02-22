using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    
    public class PonudaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PonudaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ponuda
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Ponude.Include(p => p.soba);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Ponuda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ponuda = await _context.Ponude
                .Include(p => p.soba)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ponuda == null)
            {
                return NotFound();
            }

            return View(ponuda);
        }

        // GET: Ponuda/Create
        public IActionResult Create()
        {
            ViewData["sobaId"] = new SelectList(_context.Sobe, "ID", "ID");
            return View();
        }

        // POST: Ponuda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,nazivPonude,sobaId,novaCijena")] Ponuda ponuda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ponuda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["sobaId"] = new SelectList(_context.Sobe, "ID", "ID", ponuda.sobaId);
            return View(ponuda);
        }

        // GET: Ponuda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ponuda = await _context.Ponude.FindAsync(id);
            if (ponuda == null)
            {
                return NotFound();
            }
            ViewData["sobaId"] = new SelectList(_context.Sobe, "ID", "ID", ponuda.sobaId);
            return View(ponuda);
        }

        // POST: Ponuda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,nazivPonude,sobaId,novaCijena")] Ponuda ponuda)
        {
            if (id != ponuda.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ponuda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PonudaExists(ponuda.ID))
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
            ViewData["sobaId"] = new SelectList(_context.Sobe, "ID", "ID", ponuda.sobaId);
            return View(ponuda);
        }

        // GET: Ponuda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ponuda = await _context.Ponude
                .Include(p => p.soba)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ponuda == null)
            {
                return NotFound();
            }

            return View(ponuda);
        }

        // POST: Ponuda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ponuda = await _context.Ponude.FindAsync(id);
            if (ponuda != null)
            {
                _context.Ponude.Remove(ponuda);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PonudaExists(int id)
        {
            return _context.Ponude.Any(e => e.ID == id);
        }
    }
}


